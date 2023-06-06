export interface ManagerModel {
  productId?:number;
  productName?:string;
  sectionId?:number;

}
// public int ProductId { get; set; }
// [Required, StringLength(40)]
// public string ProductName { get; set; } = default!;
// [Required, ForeignKey("Section")]
// public int SectionId { get; set; }
// public virtual Section Section { get; set; } = default!;
// public virtual ICollection<Manager> Managers { get; set; }= new List<Manager>();
