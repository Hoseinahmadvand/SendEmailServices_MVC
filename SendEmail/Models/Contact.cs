using System.ComponentModel.DataAnnotations;

namespace SendEmail.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Name { get; set; }

        public string Content { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Email { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Subject { get; set; }

        public string IPCustomer { get; set; }

        public object Attachments { get; internal set; }
    }
}
