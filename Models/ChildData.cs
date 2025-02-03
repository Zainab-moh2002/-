using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class ChildData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [Display(Name = "اسم الطفل")]
        public string ChildName { get; set; }

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]
        [Display(Name = "تاريخ ميلاد الطفل")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "الوزن مطلوب")]
        [Range(0, double.MaxValue, ErrorMessage = "الوزن غير صالح")]
        [Display(Name = "وزن الطفل (كغم)")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "حقل العلاقة مطلوب")]
        [Display(Name = "هل يوجد حالة قرابة بين الأم والأب؟")]
        public string ParentRelation { get; set; }

        [Required(ErrorMessage = "حقل نزول الماء مطلوب")]
        [Display(Name = "هل نزلت على الأم مياه قبل الولادة؟")]
        public string WaterBreak { get; set; }

        public int? WaterDuration { get; set; } // Optional field, displayed only when WaterBreak is "yes"

        [Required(ErrorMessage = "نوع الولادة مطلوب")]
        [Display(Name = "نوع الولادة")]
        public string BirthType { get; set; }

        [Required(ErrorMessage = "التشخيص مطلوب")]
        [Display(Name = "تشخيص الطفل")]
        public string Diagnosis { get; set; }

        [Required(ErrorMessage = "كود الطفل مطلوب")]
        [Display(Name = "كود الطفل")]
        public string ChildQR { get; set; }

        [Required(ErrorMessage = "درجة الطبيب المعالج مطلوبه")]
        [Display(Name = "درجة الطبيب المعالج")]
        public string AttendingPhysicianGrade { get; set; }

        [Required(ErrorMessage = "الوظيفه مطلوبه")]
        [Display(Name = "الوظيفه")]
        public string Role { get; set; }

        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Display(Name = "ارقم التليفون")]
        public int PhoneNumber { get; set; }


    }
}
