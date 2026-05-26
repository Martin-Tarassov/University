using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        [Column("FirstName")]
        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        //mis on ICollection??
        //ICollection on üldine kogutüüp, mis võimaldab hoida mitut objekti.
        //See on kasulik, kui soovite hoida näiteks mitut kursust, mida õpetaja õpetab.
        //ICollection võimaldab teil lisada, eemaldada ja hallata neid objekte kogu kogus.
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        //miks siin ei kasutata ICollection, vaid lihtsalt OfficeAssignment?
        //Sest OfficeAssignment on üks-ühele seos Instructoriga, st iga õpetaja
        //võib omada ainult ühte kontoripinda. Seega ei ole vaja kasutada
        //ICollectioni, kuna ei ole vaja hoida mitut OfficeAssignment objekti.
        //Kui kasutaksime ICollectioni, siis see tähendaks, et õpetaja
        //võiks omada mitut kontoripinda, mis ei ole meie mudelis korrektne.
        public OfficeAssignment OfficeAssignments { get; set; }
    }
}