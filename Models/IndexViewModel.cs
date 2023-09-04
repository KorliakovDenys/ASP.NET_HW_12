using System.Collections;

namespace ASP_NET_HW_12.Models {
    public class IndexViewModel{
        public IEnumerable<object>? Objects { get; set; }

        public PageViewModel? PageViewModel { get; set; }
        
    }
}