using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioDTO.Results
{
    public class GenericResult
    {
        /// <summary>
        /// ob
        /// </summary>
        public Boolean success { get; set; }
        public long total_elements { get; set; }
        public string error_msg { get; set; }
        public int error_code { get; set; }
    }
}
