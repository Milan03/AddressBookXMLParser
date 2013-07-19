/*
 * Filename: MainWindow.xaml.cs
 * Coder: Milan Sobat
 * Student #: 0469245
 * Course: INFO-5064
 * Purpose: Main window that represents an Address Book loaded from an XML file.
 * Start Date: July 15, 2013
 * Last Update: July 16, 2013
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace AddressBookXMLParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public XmlDocument g_xmlDoc = new XmlDocument();
        private string g_filepath;
        //public XmlDocument getDoc() { return g_xmlDoc; }
        public AddressBook g_addressBook = new AddressBook();

        
        public MainWindow()
        {
            InitializeComponent();
            filePathTextBox.Text = "";
        }

        /*
         * Function Name: AddContactToXml
         * Purpose:		  Adds a contact to the XML Document and saves it.
         * Accepts:		  A contact of the Contact class
         * Returns:		  Nothing
         */
        public void AddContactToXml(Contact contact)
        {
            XmlElement newItem = g_xmlDoc.CreateElement("contact");
            XmlNode parentNode = g_xmlDoc.SelectSingleNode("/addressBook");
            parentNode.InsertAfter(newItem, parentNode.LastChild);

            // contact id
            newItem = g_xmlDoc.CreateElement("contactID");
            newItem.InnerText = contact.ContactID;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // given name
            newItem = g_xmlDoc.CreateElement("givenName");
            newItem.InnerText = contact.GivenName;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // sur name
            newItem = g_xmlDoc.CreateElement("surName");
            newItem.InnerText = contact.SurName;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // home phone
            newItem = g_xmlDoc.CreateElement("homePhone");
            newItem.InnerText = contact.HomePhone;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // mobile phone
            newItem = g_xmlDoc.CreateElement("mobilePhone");
            newItem.InnerText = contact.MobilePhone;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // street address
            newItem = g_xmlDoc.CreateElement("streetAddress");
            newItem.InnerText = contact.StreetAddress;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // postal code
            newItem = g_xmlDoc.CreateElement("postalCode");
            newItem.InnerText = contact.PostalCode;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // country
            newItem = g_xmlDoc.CreateElement("country");
            newItem.InnerText = contact.Country;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // state
            newItem = g_xmlDoc.CreateElement("state");
            newItem.InnerText = contact.State;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // city
            newItem = g_xmlDoc.CreateElement("city");
            newItem.InnerText = contact.City;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            // notes
            newItem = g_xmlDoc.CreateElement("notes");
            newItem.InnerText = contact.Notes;
            parentNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            parentNode.InsertAfter(newItem, parentNode.LastChild);
            persistDocument(g_xmlDoc, g_filepath);
        }

        /*
         * Function Name: persistDocument
         * Purpose:		  Overwrites or creates a XML document being used currently.
         * Accepts:		  XmlDocument and a file path
         * Returns:		  Nothing
         */
        public static void persistDocument(XmlDocument doc, string fileName)
        {
            XmlTextWriter writer = new XmlTextWriter(fileName, null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        /*
         * Function Name: AddNewDocument
         * Purpose:		  Adds a new XML document to the current directory.
         * Accepts:		  A contact of Contact class
         * Returns:		  Nothing
         */
        public void AddNewDocument(Contact contact)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("addressBook");
            doc.AppendChild(root);
            g_xmlDoc = doc;
            g_filepath = "..\\AddressBookXML.xml";
            AddContactToXml(contact);
        }

        /*
         * Function Name: GetXmlDoc
         * Purpose:		  Retrieves a XmlDocument type from a specified filename.
         * Accepts:		  string representing the file path
         * Returns:		  XmlDocument represting the XML file
         */
        public static XmlDocument GetXmlDoc(string filename) {
            XmlReader reader = new XmlTextReader(filename);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            return doc;
        }

        /*
         * Function Name: EditContactToXml
         * Purpose:		  Edits a specified contact and saves it back to the XML file.
         * Accepts:		  A contact of Contact class
         * Returns:		  Nothing
         */
        public void EditContactToXml(Contact contact)
        {
            XmlNodeList contacts = g_xmlDoc.GetElementsByTagName("contact");
            foreach (XmlNode node in contacts)
            {
                string contactID = node.FirstChild.FirstChild.InnerText;
                if (contactID == contact.ContactID)
                {
                    node["givenName"].InnerText = contact.GivenName;
                    node["surName"].InnerText = contact.SurName;
                    node["homePhone"].InnerText = contact.HomePhone;
                    node["mobilePhone"].InnerText = contact.MobilePhone;
                    node["streetAddress"].InnerText = contact.StreetAddress;
                    node["postalCode"].InnerText = contact.PostalCode;
                    node["country"].InnerText = contact.Country;
                    node["state"].InnerText = contact.State;
                    node["city"].InnerText = contact.City;
                    node["notes"].InnerText = contact.Notes;
                    persistDocument(g_xmlDoc, g_filepath);
                }
            }
        }

        /*
         * Function Name: RemoveContactFromXml
         * Purpose:		  Removes a contact from the XML document and saves it.
         * Accepts:		  A contact of class Contact
         * Returns:		  Nothing
         */
        public void RemoveContactFromXml(Contact contact)
        {
            XmlElement removeElement = (XmlElement)g_xmlDoc.SelectSingleNode("/addressBook/contact[contactID=\"" + contact.ContactID + "\"]");
            if (removeElement != null)
                removeElement.ParentNode.RemoveChild(removeElement);

            persistDocument(g_xmlDoc, g_filepath);
            //XmlNode removedNode = g_xmlDoc.SelectSingleNode("addressBook/contact[last()]");
            
        }

        /*
         * Function Name: StreamContacts
         * Purpose:		  Reads an XML file specified for this program and builds Contact
         *                which can be added to the data model.
         * Accepts:		  string representing a file path
         * Returns:		  Contact of type IEnumberable
         */
        public static IEnumerable<Contact> StreamContacts(string filename)
        {
            using (XmlReader reader = XmlReader.Create(filename))
            {
                string contactID = null;
                string givenName = null;
                string surName = null;
                string homePhone = null;
                string mobilePhone = null;
                string streetAddress = null;
                string postalCode = null;
                string country = null;
                string state = null;
                string city = null;
                string notes = null;
                
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && 
                        reader.Name == "contact")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "contactID")
                            {
                                contactID = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (contactID)

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "givenName")
                            {
                                givenName = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (givenName)

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "surName")
                            {
                                surName = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (surName)

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "homePhone")
                            {
                                homePhone = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (homePhone)

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "mobilePhone")
                            {
                                mobilePhone = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (mobilePhone)

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "streetAddress")
                            {
                                streetAddress = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (streetAddress)

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "postalCode")
                            {
                                postalCode = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (postalCode)


                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "country")
                            {
                                country = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (country)


                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "state")
                            {
                                state = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (state)


                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "city")
                            {
                                city = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (city)


                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "notes")
                            {
                                notes = reader.ReadInnerXml();
                                break;
                            }
                        }//end while (notes)

                        yield return new Contact()
                        {
                            ContactID = contactID,
                            GivenName = givenName,
                            SurName = surName,
                            HomePhone = homePhone,
                            MobilePhone = mobilePhone,
                            StreetAddress = streetAddress,
                            PostalCode = postalCode,
                            Country = country,
                            State = state,
                            City = city,
                            Notes = notes
                        };
                    }//end if (contact)
                }//end while(reader.Read())
            }
        }

        // Browse Button Event Handler
        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                g_filepath = filename;
                g_addressBook.removeAllContacts();
                g_xmlDoc = GetXmlDoc(filename);
                foreach (var contact in StreamContacts(filename))
                {
                    g_addressBook.addContact(contact);

                }
                List<Contact> contacts = g_addressBook.getContacts;

                if (contacts.Count == 0)
                {
                    MessageBox.Show("Invalid document. Please try again", "File Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
                else
                {
                    contactsListBox.IsEnabled = true;
                    contactsListBox.ItemsSource = contacts;
                    filePathTextBox.Text = filename;
                }
            }
        }

        /*
         * Function Name: ClearTextBoxes
         * Purpose:		  Clears all of the displayable textboxes.
         * Accepts:		  Nothing
         * Returns:		  Nothing
         */
        public void ClearTextBoxes()
        {
            contactIDTextBox.Text = "";
            givenNameTextBox.Text = "";
            surNameTextBox.Text = "";
            homePhoneTextBox.Text = "";
            mobilePhoneTextBox.Text = "";
            addressTextBox.Text = "";
            pcTextBox.Text = "";
            coTextBox.Text = "";
            stTextBox.Text = "";
            ciTextBox.Text = "";
            notesTextBox.Text = "";
        }

        /*
         * Function Name: EnableTextBoxesSave
         * Purpose:		  Enables all text boxes and save button for editting purposes.
         * Accepts:		  Nothing
         * Returns:		  Nothing
         */
        public void EnableTextBoxesSave()
        {
            contactIDTextBox.IsEnabled = true;
            givenNameTextBox.IsEnabled = true;
            surNameTextBox.IsEnabled = true;
            homePhoneTextBox.IsEnabled = true;
            mobilePhoneTextBox.IsEnabled = true;
            addressTextBox.IsEnabled = true;
            pcTextBox.IsEnabled = true;
            coTextBox.IsEnabled = true;
            stTextBox.IsEnabled = true;
            ciTextBox.IsEnabled = true;
            notesTextBox.IsEnabled = true;
            SaveButton.IsEnabled = true;
        }

        // ListBox Selection Changed Event Handler
        private void contactsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearTextBoxes();

            int contactNum = contactsListBox.SelectedIndex;
            List<Contact> contacts = g_addressBook.getContacts;
            contactIDTextBox.Text = contacts[contactNum].ContactID;
            givenNameTextBox.Text = contacts[contactNum].GivenName;
            surNameTextBox.Text = contacts[contactNum].SurName;
            homePhoneTextBox.Text = contacts[contactNum].HomePhone;
            mobilePhoneTextBox.Text = contacts[contactNum].MobilePhone;
            addressTextBox.Text = contacts[contactNum].StreetAddress;
            pcTextBox.Text = contacts[contactNum].PostalCode;
            coTextBox.Text = contacts[contactNum].Country;
            stTextBox.Text = contacts[contactNum].State;
            ciTextBox.Text = contacts[contactNum].City;
            notesTextBox.Text = contacts[contactNum].Notes;
        }

        // Save button Event Handler
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Edit mode
            if (contactsListBox.IsEnabled == true)
            {
                List<Contact> contacts = g_addressBook.getContacts;
                int selectedContact = contactsListBox.SelectedIndex;
                Contact selectedCon = contacts[selectedContact];
                Contact editedContact = new Contact();
                editedContact.ContactID = contactIDTextBox.Text;
                editedContact.GivenName = givenNameTextBox.Text;
                editedContact.SurName = surNameTextBox.Text;
                editedContact.HomePhone = homePhoneTextBox.Text;
                editedContact.MobilePhone = mobilePhoneTextBox.Text;
                editedContact.StreetAddress = addressTextBox.Text;
                editedContact.PostalCode = pcTextBox.Text;
                editedContact.Country = coTextBox.Text;
                editedContact.State = stTextBox.Text;
                editedContact.City = ciTextBox.Text;
                editedContact.Notes = notesTextBox.Text;
                if (editedContact.ContactID == selectedCon.ContactID &&
                    editedContact.GivenName == selectedCon.GivenName &&
                    editedContact.SurName == selectedCon.SurName &&
                    editedContact.HomePhone == selectedCon.HomePhone &&
                    editedContact.MobilePhone == selectedCon.MobilePhone &&
                    editedContact.StreetAddress == selectedCon.StreetAddress &&
                    editedContact.PostalCode == selectedCon.PostalCode &&
                    editedContact.Country == selectedCon.Country &&
                    editedContact.State == selectedCon.State &&
                    editedContact.Notes == selectedCon.Notes)
                    MessageBox.Show("Please change attributes before saving.", "Alert", MessageBoxButton.OK);
                else
                {
                    EditContactToXml(editedContact);
                    MessageBox.Show("Contact saved, program will relaunch. Please choose the xml document to re-view.", "Alert", MessageBoxButton.OK);
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }

            }
            // Add new mode
            else if (filePathTextBox.Text != "")
            {

                Contact newContact = new Contact();
                newContact.ContactID = contactIDTextBox.Text;
                newContact.GivenName = givenNameTextBox.Text;
                newContact.SurName = surNameTextBox.Text;
                newContact.HomePhone = homePhoneTextBox.Text;
                newContact.MobilePhone = mobilePhoneTextBox.Text;
                newContact.StreetAddress = addressTextBox.Text;
                newContact.PostalCode = pcTextBox.Text;
                newContact.Country = coTextBox.Text;
                newContact.State = stTextBox.Text;
                newContact.City = ciTextBox.Text;
                newContact.Notes = notesTextBox.Text;
                AddContactToXml(newContact);
                MessageBox.Show("Contact saved, program will relaunch. Please choose the xml document to re-view.", "Alert", MessageBoxButton.OK);
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else // new file
            {
                Contact newContact = new Contact();
                newContact.ContactID = contactIDTextBox.Text;
                newContact.GivenName = givenNameTextBox.Text;
                newContact.SurName = surNameTextBox.Text;
                newContact.HomePhone = homePhoneTextBox.Text;
                newContact.MobilePhone = mobilePhoneTextBox.Text;
                newContact.StreetAddress = addressTextBox.Text;
                newContact.PostalCode = pcTextBox.Text;
                newContact.Country = coTextBox.Text;
                newContact.State = stTextBox.Text;
                newContact.City = ciTextBox.Text;
                newContact.Notes = notesTextBox.Text;
                AddNewDocument(newContact);
                MessageBox.Show("New XML Document created.", "Alert", MessageBoxButton.OK);
                // load new file
                foreach (var contact in StreamContacts(g_filepath))
                {
                    g_addressBook.addContact(contact);
                }
                List<Contact> contacts = g_addressBook.getContacts;
                filePathTextBox.Text = g_filepath;
                contactsListBox.ItemsSource = contacts;
            }
        }

        // Edit button Event Handler
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            contactsListBox.IsEnabled = true;
            EnableTextBoxesSave();
            DeleteButton.IsEnabled = true;
        }

        // New button Event Handler
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
                ClearTextBoxes();
                EnableTextBoxesSave();
                DeleteButton.IsEnabled = false;
                contactsListBox.IsEnabled = false;
        }

        // Contacts list box IsEnabled event handler
        private void contactsListBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<Contact> contacts = g_addressBook.getContacts;
            if (contacts.Count > 0)
            {
                
                contactsListBox.ItemsSource = contacts;
                //contactsListBox.Items.Refresh();
            }
        }

        // Delete button event handler
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            List<Contact> contacts = g_addressBook.getContacts;
            int selectedContact = contactsListBox.SelectedIndex;
            RemoveContactFromXml(contacts[selectedContact]);
            MessageBox.Show("Contact removed, program will relaunch. Please choose the xml document to re-view.", "Alert", MessageBoxButton.OK);
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        // Close button event handler
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
