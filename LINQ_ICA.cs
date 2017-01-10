//////////////////////////////////////////////////////////
//Jared, Kyle, Angelo, Cheyanne
//
//LINQ ICA displays our understanding of Linq statements
//via a simple app that displays and sorts the first 100
//elements in the periodic table. App also estimates 
//molar mass of molecules typed in by the user
//
//Last updated Sep 27, 2016
//////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CMPE2800_LINQICA
{
    public partial class LINQ_ICA : Form
    {
        //gridview binder
        BindingSource bs_ElementOutput;

        #region Init
        public LINQ_ICA()
        {
            InitializeComponent();
            Init();
        }

        //initializes class level objects
        private void Init()
        {
            bs_ElementOutput = new BindingSource();

            //bind the bindingsource to the gridview
            _dgv_elementList.DataSource = bs_ElementOutput;  
        }
        #endregion

        #region Events
        private void _btn_sortName_Click(object sender, EventArgs e)
        {
            //order list by the name portion of the value, turn back to dictionary
            //and bind to data source
            BindData(ElementLookUp.Table.OrderBy(o => o.Value.name).ToDictionary(o => o.Key, o => o.Value));
            _tbx_chemFormula.Clear();
        }

        //Filters element list to those with a single char and binds to datagrid
        private void _btn_singleCharFilter_Click(object sender, EventArgs e)
        {
            //filter down to 1 char keys, convert back to dictionary and 
            //bind new data to the gridview
            BindData(ElementLookUp.Table.Where(o => o.Key.Length < 2)
                .ToDictionary(v => v.Key, v => v.Value));
            _tbx_chemFormula.Clear();
        }

        //Sorts elements by atomic number and binds to datagrid
        private void _btn_atomicSort_Click(object sender, EventArgs e)
        {
            //order list by atomic number portion of the value, return to dictionary using
            //same key value pair and pass to binding function
            BindData(ElementLookUp.Table.OrderBy(o => o.Value.ATOMIC_NUMBER)
                .ToDictionary(o => o.Key, o => o.Value));
            _tbx_chemFormula.Clear();
        }

        //Updates the datagridview to a new data table if an element or more can be 
        //parsed from the input string
        private void _tbx_chemFormula_TextChanged(object sender, EventArgs e)
        {
            ParseTextBox();
        }
        #endregion

        #region Support Functions
        private void BindData(Dictionary<string, Element> inTable)
        {
            bs_ElementOutput.DataSource = from el in inTable
                                          select new
                                          {
                                              AtomicNumber = el.Value.ATOMIC_NUMBER,
                                              Name = el.Value.name,
                                              Symbol = el.Key,
                                              Mass = el.Value.ATOMIC_WEIGHT
                                          };
        }

        private void ParseTextBox()
        {
            _tbx_molarMass.BackColor = Color.White;
            Regex parseReg = new Regex("[A-Z][0-9a-z]?[0-9]?");

            //holds the txt retrieved from the input textBox
            string inputText = _tbx_chemFormula.Text;

            //new dictionary holding all the matches and their frequency
            Dictionary<string, int> d_Parse = new Dictionary<string, int>();

            //retrieve all of the matches from the textbox compared to the regEx
            var match = parseReg.Matches(inputText);

            //holds the string that holds all the matching strings
            string matchLength = "";

            foreach (var v in match)
                matchLength += v.ToString();

            //if the length of the matching string is shorter than the input text
            //we have filtered out some text from the input textBox, turn outPut txt colour yellow
            if (matchLength.Length < inputText.Length)
                _tbx_molarMass.ForeColor = Color.Yellow;

            //if the length of the matching string is shorter than the input text by two or more
            //we have filtered out some text from the input textBox, turn outPut txt colour yellow
            else if (matchLength.Length < inputText.Length + 2)
                _tbx_molarMass.ForeColor = Color.Red;

            foreach (var v in match)
            {
                //convert v from match object to string
                string s = v.ToString();

                //used to store a number from the end of a match (H2)
                int savedNum = 0;

                //if the last char is a digit, remove it and save it for later
                if (char.IsDigit(s[s.Length - 1]))
                {
                    savedNum = int.Parse(s[s.Length - 1].ToString());
                    s = s.TrimEnd(s[s.Length - 1]);
                }

                if (savedNum == 0)
                    savedNum = 1;
                //if the new dictionary does not contain the match as a key, create the key and add the value
                if (!d_Parse.ContainsKey(s))
                    d_Parse.Add(s, savedNum);
                //if it does contain it, just add the value
                else
                    d_Parse[s] += savedNum;
            }

            List<string> tempList = new List<string>();

            //itterates through the dictionary created from the input txtBox and adds any elements not in the original dictionary
            foreach (KeyValuePair<string, int> kvp in d_Parse)
                //if the original dictionary doesn't contain the key from the new dictionary, add it to a templist
                if (!ElementLookUp.Table.ContainsKey(kvp.Key) )
                    tempList.Add(kvp.Key);

            //testing the keys to see if they can be split and ToUpper'd to see if they match the Original dictionary
            foreach (string s in tempList)
            {
                for (int i = 0; i < s.Length; i++)
                    //add the element to the parsed dictionary if the original dictionary contains the 'modified' error key
                    if (ElementLookUp.Table.ContainsKey(s[i].ToString().ToUpper()))
                    {
                        if (d_Parse.ContainsKey(s[i].ToString().ToUpper()))
                            //exists already 
                            d_Parse[s[i].ToString().ToUpper()]++;
                        else
                            d_Parse.Add(s[i].ToString().ToUpper(), 1);
                    }
            }

            //does not use support function as the linq expression is unique
            //join to get a collection of elements that exist in both dictionaries
                //(means that the searched items exist in the actual table)
            var temp = from w in ElementLookUp.Table.OrderBy(o => o.Value.name.ToLower())
                                          join s in d_Parse on w.Key equals s.Key
                                          select new
                                          {
                                              Element = w.Value.name,
                                              Count = s.Value,
                                              Mass = w.Value.ATOMIC_WEIGHT,
                                              TotalMass = s.Value * double.Parse(w.Value.ATOMIC_WEIGHT.ToString())
                                          };
            bs_ElementOutput.DataSource = temp;
            double totalMass = 0;

            //adding up all the elements for total mass
            foreach (var v in temp)
                totalMass += v.TotalMass;

            //figure out how wrong the input is
            //1 error is ok, 2 is too many
            int numError = 0;
            foreach (KeyValuePair<string, int> kvp in d_Parse)
                if (!ElementLookUp.Table.ContainsKey(kvp.Key))
                    numError++;
            //red if more than one error
            if (numError > 1)
                _tbx_molarMass.ForeColor = Color.Red;

            //green if no errors
            else if (numError == 0 && _tbx_molarMass.ForeColor != Color.Yellow)
                _tbx_molarMass.ForeColor = Color.Green;

            //enter the value into the txtbox
            _tbx_molarMass.Text = totalMass.ToString();
        }
        #endregion
    }
}