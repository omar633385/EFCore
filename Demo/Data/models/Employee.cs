using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.models
{
    //There are 4 ways for mapping from Code To Database
    //1.By Convention(Default Behavoir)
    //2.Data Annotation(set of Attributes used for Validation) Not All Method reflects to database but it is used more between front-end and backend[Viewmodels,DTOs]


    #region ByConvention
    //internal class Employee
    //{
    //    public int Id { get; set; }
    //    public string? Name { get; set; }
    //    public double Salary { get; set; }
    //    public int? Age { get; set; }
    //}
    #endregion
    [Table("Employees",Schema ="dbo")] //equivlant to dbset
    internal class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //identity (1,1) => To control it use fluent api
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] //To Cancel Identity
        public int EmpId { get; set; }
        [Required] // required in database
        //required keyword  means => required at application
        [AllowNull]
        [Column(TypeName ="varchar(50)")]
        [MaxLength(50)]
        [MinLength(3)]
        public required string? Name { get; set; }
        [Column(TypeName ="money")]
        public double Salary { get; set; }
        [Range(20,60)]
        public int? Age { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [NotMapped] //used as drieven attribute in sql
        public string Phone { get; set; }
    }
}
