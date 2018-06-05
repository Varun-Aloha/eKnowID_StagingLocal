namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CMSHomePage")]
    public partial class CMSHomePage
    {
        [Key]
        public int CMSHomeID { get; set; }

        [Required]
        [StringLength(350)]
        public string testimonials_content { get; set; }

        [Required]
        [StringLength(30)]
        public string testimonials_Sign_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string testimonials_Sign_CompanyName { get; set; }

        [Required]
        [StringLength(30)]
        public string testimonials_imageName { get; set; }

        [Required]
        [StringLength(50)]
        public string Blog_Header { get; set; }

        [Required]
        [StringLength(210)]
        public string Blog_Content { get; set; }

        [Required]
        public string YoutubeSrc { get; set; }

        public bool PreviewFlag { get; set; }
    }
}
