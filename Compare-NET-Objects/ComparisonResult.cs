//TODO:  Refactor CompareObjects.cs to use ComparisionResult

//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;
//using KellermanSoftware.CompareNetObjects;

//namespace KellermanSoftware.CompareNETObjects
//{
//    /// <summary>
//    /// Details about the comparison
//    /// </summary>
//    public class ComparisonResult
//    {
//        /// <summary>
//        /// Set the configuration for the comparison
//        /// </summary>
//        /// <param name="config"></param>
//        public ComparisonResult(Config config)
//        {
//            Config = config;
//        }

//        /// <summary>
//        /// Configuration
//        /// </summary>
//        public Config Config { get; private set; }

//        internal readonly Stopwatch Watch = new Stopwatch();

//        /// <summary>
//        /// Keep track of parent objects in the object hiearchy
//        /// </summary>
//        internal readonly Dictionary<int, int> Parents = new Dictionary<int, int>();

//        /// <summary>
//        /// The amount of time in milliseconds it took for the comparison
//        /// </summary>
//        public long ElapsedMilliseconds
//        {
//            get { return Watch.ElapsedMilliseconds; }
//        }

//        /// <summary>
//        /// The differences found during the compare
//        /// </summary>
//        public List<Difference> Differences { get; set; }

//        /// <summary>
//        /// The differences found in a string suitable for a textbox
//        /// </summary>
//        public string DifferencesString
//        {
//            get
//            {
//                StringBuilder sb = new StringBuilder(4096);

//                sb.AppendLine();
//                sb.AppendLine("Begin Differences:");

//                foreach (Difference item in Differences)
//                {
//                    sb.AppendLine(item.ToString());
//                }

//                sb.AppendFormat("End Differences (Maximum of {0} differences shown).", Config.MaxDifferences);

//                return sb.ToString();
//            }
//        }
//    }
//}
