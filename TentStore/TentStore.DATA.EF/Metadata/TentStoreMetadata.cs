using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TentStore.DATA.EF
{

    #region Brand Metadata
    public class BrandMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(25,ErrorMessage ="*25 characters or less")]
        [Display(Name ="Brand")]
        public string BrandName { get; set; }
    }

    [MetadataType(typeof(BrandMetadata))]
    public partial class Brand
    {

    }

    #endregion

    #region Capacity Metadata
    public class CapacityMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(10,ErrorMessage ="*10 characters or less")]
        public string Capacity1 { get; set; }
    }
    [MetadataType(typeof(CapacityMetadata))]
    public partial class Capacity
    {

    }
    #endregion

    #region Dimension Metadata
    public class DimensionMetadata
    {
        [Required(ErrorMessage = "*Required")]
        [StringLength(25, ErrorMessage = "*25 characters or less")]
        [Display(Name ="Dimensions")]
        public string DimensionRange { get; set; }
    }
    [MetadataType(typeof(DimensionMetadata))]
    public partial class Dimension
    {

    }
    #endregion

    #region Manufacturer Metadata
    public class ManufacturerMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [Display(Name="Manufacturer")]
        [StringLength(100,ErrorMessage ="*100 characters or less")]
        public string ManufacturerName { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(25, ErrorMessage = "*25 characters or less")]
        public string City { get; set; }
        [DisplayFormat(NullDisplayText =  "[N/A]")]
        [StringLength(2,MinimumLength =2, ErrorMessage = "*2 characters")]
        public string State { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(25, ErrorMessage = "*25 characters or less")]
        public string Country { get; set; }
    }
    [MetadataType(typeof(ManufacturerMetadata))]
    public partial class Manufacturer
    {

    }
    #endregion

    #region PoleMaterial Metadata
    public class PoleMaterialMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [Display(Name ="Pole Material")]
        [StringLength(20,ErrorMessage ="*20 characters or less.")]
        public string PoleMaterial1 { get; set; }
    }
    [MetadataType(typeof(PoleMaterialMetadata))]
    public partial class PoleMaterial
    {

    }
    #endregion

    #region Season Metadata
    public class SeasonMetadata
    {
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Season")]
        [StringLength(100, ErrorMessage = "*100 characters or less.")]
        public string Season1 { get; set; }
    }
    [MetadataType(typeof(SeasonMetadata))]
    public partial class Season
    {

    }
    #endregion

    #region StatusID Metadata
    public class StatusIDMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(20,ErrorMessage ="*20 characters or less")]
        public string Status { get; set; }
    }
    [MetadataType(typeof(StatusIDMetadata))]
    public partial class StatusID
    {

    }
    #endregion

    #region Tent Metadata
    public class TentMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(50,ErrorMessage ="*50 Characters or less")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Required")]
        
        public int BrandID { get; set; }
        [Required(ErrorMessage = "*Required")]
        
        public int StatusID { get; set; }
        
        [Required(ErrorMessage = "*Required")]
        public int ManufacturerID { get; set; }
        [Required(ErrorMessage = "*Required")]
        
        public int DimensionsID { get; set; }
        [Required(ErrorMessage = "*Required")]
        
        public int CapacityID { get; set; }
        [Required(ErrorMessage = "*Required")]
        
        public int TentMaterialID { get; set; }
        [Required(ErrorMessage = "*Required")]
        
        public int PoleMaterialID { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Range(0, double.MaxValue, ErrorMessage = "*Must be Greater than 0")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "*Required")]
        
        public int SeasonID { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Range(0, double.MaxValue, ErrorMessage = "*Must be Greater than 0")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name="Waterproof")]
        public bool isWaterProof { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name="Discontinued")]
        public bool isDiscontinued { get; set; }
        [DisplayFormat(NullDisplayText ="N/A")]
        public string Description { get; set; }
        [Display(Name="Image")]
        public string ImageURL { get; set; }
    }
    [MetadataType(typeof(TentMetadata))]
    public partial class Tent
    {

    }
    #endregion 
    
    #region TentMaterial Metadata
    public class TentMaterialMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(20,ErrorMessage ="*20 characters or less")]
        public string TentMaterial1 { get; set; }
    }
    [MetadataType(typeof(TentMaterialMetadata))]
    public partial class TentMaterial
    {

    }
    #endregion
    
    #region Department Metadata
    public class DepartmentMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(50,ErrorMessage ="50 characters or less")]
        public string DeptName { get; set; }
    }
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department
    {

    }
    #endregion
    
    #region Employee Metadata
    public class EmployeeMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [Display(Name ="First Name")]
        [StringLength(50,ErrorMessage ="*50 characters or less")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "*50 characters or less")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(50, ErrorMessage = "*50 characters or less")]
        public string Position { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "*Must be Greater than 0")]
        public Nullable<int> ReportsTo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Range(0, int.MaxValue, ErrorMessage = "*Must be Greater than 0")]
        public int DeptID { get; set; }
    }
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {

    }
    #endregion 
    
}
