using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormsApp3
{

    [XmlRoot("purchase-order")]
    public class PurchaseOrder
    {
        [XmlAttribute("PurchaseOrderNumber")]
        public string PurchaseOrderNumber { get; set; }
        [XmlElement("Address")]
        public Address Address { get; set; }
        [XmlArray("Items"), XmlArrayItem("Item")]
        public List<Item> Items { get; set; }
    }

    public class Address
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Street")]
        public string Street { get; set; }
        [XmlElement("City")]
        public string City { get; set; }
        [XmlElement("State")]
        public string State { get; set; }
        [XmlElement("Zip")]
        public string Zip { get; set; }
        [XmlElement("Country")]
        public string Country { get; set; }
    }

    public class Item
    {
        [XmlAttribute("PartNumber")]
        public string PartNumber { get; set; }

        [XmlElement("ProductName")]
        public string ProductName { get; set; }
    }


} 



