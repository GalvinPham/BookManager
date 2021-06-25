namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookMan")]
    public partial class BookMan
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ID không được để trống")]
        public int ID { get; set; }

        
        [Column(Order = 1)]        
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100, ErrorMessage = "Tiêu đề không quá 100 ký tự")]
        public string Title { get; set; }

        
        [Column(Order = 2)]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Description { get; set; }

        
        [Column(Order = 3)]
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(30, ErrorMessage = "Tên tác giả không quá 30 ký tự")]
        public string Author { get; set; }

       
        [Column(Order = 4)]
        [StringLength(255)]
        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        public string Images { get; set; }

        
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000 - 1.000.000")]
        public int Price { get; set; }
    }
    
}
