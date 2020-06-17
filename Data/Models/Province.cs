using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace covid19.Data
{
    public class Geography
    {
        #region Constructor
        public Geography()
        {

        }
        #endregion

        #region Properties
        [Key]
        [Required]
        /// <summary>
        /// The unique name of geography
        /// </summary>
        public string Name {get; set;}
        public int Infected {get; set;}
        public int Dead {get; set;}
        #endregion

        #region Relations
        public List<CPI> CPIs {get; set;}
        #endregion
    }
}