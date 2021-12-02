using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Hellocnm.Models
{
    [Table("Person")]
    public class readerinformation
    {
        [Key]
        public int p_id { get; set; }


        [Column("p_kind")]
        public int Kind { get; set; }


        [Column("p_name")]
        public string Name { get; set; }



        [Column("p_sex")]
        public string Sex { get; set; }

        [Column("p_phone")]
        public string Phone { get; set; }

        [Column("p_email")]
        public string Email { get; set; }

        [Column("borrow_num")]
        public int Borrownumber { get; set; }
        [Column("p_school")]
        public string College { get; set; }
        [Column("p_address")]
        public string Address { get; set; }
        [Column("remark")]
        public string Remark { get; set; }
    }
    [Table("Person_kind")]
    public class 读者分类
    {


        [Key]
        public int kind_num { get; set; }
        [Column("p_id")]
        public int ID { get; set; }
        [Column("kind_name")]
        public string DictName { get; set; }

        [Column("limit_num")]
        public int LimitNumber { get; set; }

        [Column("limit_day")]
        public int LimitDay { get; set; }

    }
    [Table("borrow_history")]
    public class 借阅历史
    {
        public int ID { get; set; }

        [Column("p_id")]
        [Display(Name = "读者码")]
        public string ReaderCode { get; set; }

        [Column("book_id")]
        [Display(Name = "图书索引码")]
        public string BookCode { get; set; }
        [Column("borrow_date")]
        [Display(Name = "借阅时间")]
        public string BorrowDate { get; set; }
        [Column("should_return_date")]
        [Display(Name = "应归还时间")]
        public string ShouldReturnDate { get; set; }
        [Column("real_return_date")]
        [Display(Name = "实际归还时间")]
        public string RealReturnDate { get; set; }
    }
}
