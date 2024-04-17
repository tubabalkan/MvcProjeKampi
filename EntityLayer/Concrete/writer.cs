using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class writer
    {
        [Key]
        public int writerId { get; set; }
        [StringLength(50)]
        public string writerName { get; set; }
        [StringLength(50)]
        public string writerSurname { get; set; }
        [StringLength(100)]
        public string writerImage { get; set; }
        [StringLength(50)]
        public string writerMail { get; set; }
        [StringLength(20)]
        public string writerPassword { get; set; }


        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
