/// Angelo's work
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


//XML file source http://www.w3.org/XML/Binary/2005/03/test-data/Over100K/periodic.xml

namespace CMPE2800_LINQICA
{
    /// <summary>
    /// A class to hold our eleis
    /// by Angelo
    /// </summary>
    public class Element
    {
        /// <summary>
        /// An Internal Constructor never ment to be called Consider using ElementLookUp.Table[with the Sybol] inplace
        /// </summary>
        /// <param name="_SYMBOL">Our SYMBOL ex. Au </param>
        /// <param name="_name">The eles full name</param>
        /// <param name="_ATOMIC_WEIGHT">the atomic wieght of the element</param>
        /// <param name="_ATOMIC_NUMBER">the atomic number of the element</param>
        internal Element(string _SYMBOL, string _name, string _ATOMIC_WEIGHT, string _ATOMIC_NUMBER)
        {
            if (_SYMBOL == null || _name == null || _ATOMIC_WEIGHT == null || _ATOMIC_NUMBER == null)
                throw new ArgumentNullException("An argument was null");
            SYMBOL = _SYMBOL;
            name = _name;
            ATOMIC_WEIGHT = double.Parse(_ATOMIC_WEIGHT);
            ATOMIC_NUMBER = int.Parse(_ATOMIC_NUMBER);
        }
        /// <summary>
        /// the elements full name
        /// </summary>
        public string name { get; private set; }
        /// <summary>
        /// the atomic wieght of the element
        /// </summary>
        public double ATOMIC_WEIGHT { get; private set; }
        /// <summary>
        /// the atomic number of the element
        /// </summary>
        public int ATOMIC_NUMBER { get; private set; }
        /// <summary>
        /// Our SYMBOL ex. Au
        /// </summary>
        public string SYMBOL { get; private set; }
    }
    /// <summary>
    /// the look up class is static just call once
    /// by Angelo
    /// </summary>
    static class ElementLookUp
    {
        /// <summary>
        /// the master list of all the elements
        /// </summary>
        public static readonly Dictionary<string, Element> Table = new Dictionary<string, Element>();

        /// <summary>
        /// a static constructor to get the table from the xml
        /// </summary>
        static ElementLookUp()
        {
            //a string we will read to
            string XMLRaw;

            ///DO NOT MOVE XML FILE FROM SOURCE files <---------------------!!!! but you can move your folder for the project
            // try and read the file to a string
            using (StreamReader SR = File.OpenText(Environment.CurrentDirectory + @"\..\..\Periodic table.txt"))
            {
                XMLRaw = SR.ReadToEnd();
            }

            //start a parser
            using (XmlReader XR = XmlReader.Create(new StringReader(XMLRaw)))
            {
                // the builder of a ele class
                string name = null;
                string ATOMIC_WEIGHT = null;
                string ATOMIC_NUMBER = null;
                string SYMBOL = null;
                Element Ele = null;
                // while we have a line to read read
                while (XR.Read())
                {
                    
                    switch (XR.NodeType)
                    {
                        //if it is an ele check the space name
                        case XmlNodeType.Element:
                            switch (XR.Name)
                            {
                                // store proper
                                case "NAME":
                                    name = XR.ReadElementContentAsString();
                                    break;
                                case "ATOMIC_WEIGHT":
                                    ATOMIC_WEIGHT = XR.ReadElementContentAsString();
                                    break;
                                case "ATOMIC_NUMBER":
                                    ATOMIC_NUMBER = XR.ReadElementContentAsString();
                                    break;
                                case "SYMBOL":
                                    SYMBOL = XR.ReadElementContentAsString();
                                    break;
                            }
                            break;
                            //if we are closing a element and it is an atom we are done
                        case XmlNodeType.EndElement:
                            if (XR.Name == "ATOM")
                            {
                                //store it and move on
                                Ele = new Element(SYMBOL, name, ATOMIC_WEIGHT, ATOMIC_NUMBER);
                                Table.Add(Ele.SYMBOL, Ele);
                            }
                            break;
                    }
                }
            }
        }
 
    }
}
