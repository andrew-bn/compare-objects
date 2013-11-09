//TODO:  Refactor CompareObjects.cs to use Config

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace KellermanSoftware.CompareNETObjects
//{
//    /// <summary>
//    /// Configuration
//    /// </summary>
//    public class Config
//    {

//        /// <summary>
//        /// Show breadcrumb at each stage of the comparision.  
//        /// This is useful for debugging deep object graphs.
//        /// The default is false
//        /// </summary>
//        public bool ShowBreadcrumb { get; set; }

//        /// <summary>
//        /// Ignore classes, properties, or fields by name during the comparison.
//        /// Case sensitive.
//        /// </summary>
//        /// <example>ElementsToIgnore.Add("CreditCardNumber")</example>
//        public List<string> ElementsToIgnore { get; set; }

//        /// <summary>
//        /// Only compare elements by name for classes, properties, and fields
//        /// Case sensitive.
//        /// </summary>
//        /// <example>ElementsToInclude.Add("FirstName")</example>
//        public List<string> ElementsToInclude { get; set; }

//        //Security restriction in Silverlight prevents getting private properties and fields
//#if !SILVERLIGHT
//        /// <summary>
//        /// If true, private properties and fields will be compared. The default is false.  Silverlight and WinRT restricts access to private variables.
//        /// </summary>
//        public bool ComparePrivateProperties { get; set; }

//        /// <summary>
//        /// If true, private fields will be compared. The default is false.  Silverlight and WinRT restricts access to private variables.
//        /// </summary>
//        public bool ComparePrivateFields { get; set; }
//#endif

//        /// <summary>
//        /// If true, static properties will be compared.  The default is true.
//        /// </summary>
//        public bool CompareStaticProperties { get; set; }

//        /// <summary>
//        /// If true, static fields will be compared.  The default is true.
//        /// </summary>
//        public bool CompareStaticFields { get; set; }

//        /// <summary>
//        /// If true, child objects will be compared. The default is true. 
//        /// If false, and a list or array is compared list items will be compared but not their children.
//        /// </summary>
//        public bool CompareChildren { get; set; }

//        /// <summary>
//        /// If true, compare read only properties (only the getter is implemented).
//        /// The default is true.
//        /// </summary>
//        public bool CompareReadOnly { get; set; }

//        /// <summary>
//        /// If true, compare fields of a class (see also CompareProperties).
//        /// The default is true.
//        /// </summary>
//        public bool CompareFields { get; set; }

//        /// <summary>
//        /// If true, compare each item within a collection to every item in the other (warning, setting this to true significantly impacts performance).
//        /// The default is false.
//        /// </summary>
//        public bool IgnoreCollectionOrder { get; set; }

//        /// <summary>
//        /// If true, compare properties of a class (see also CompareFields).
//        /// The default is true.
//        /// </summary>
//        public bool CompareProperties { get; set; }

//        /// <summary>
//        /// The maximum number of differences to detect
//        /// </summary>
//        /// <remarks>
//        /// Default is 1 for performance reasons.
//        /// </remarks>
//        public int MaxDifferences { get; set; }
//    }
//}
