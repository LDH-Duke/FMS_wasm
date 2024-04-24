using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("BUILDINGINFO")]
public partial class Buildinginfo
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("CODE")]
    [StringLength(25)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [Column("NAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("ADDRESS")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("USAGE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Usage { get; set; }

    [Column("CONST_COMP")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ConstComp { get; set; }

    [Column("COMPLETION_DATE", TypeName = "datetime")]
    public DateTime? CompletionDate { get; set; }

    [Column("BUILDING_STRUCTURE")]
    [StringLength(30)]
    [Unicode(false)]
    public string? BuildingStructure { get; set; }

    [Column("ROOT_STRUCTURE")]
    [StringLength(30)]
    [Unicode(false)]
    public string? RootStructure { get; set; }

    [Column("GROSSFLOORAREA")]
    public double? Grossfloorarea { get; set; }

    [Column("LANDAREA")]
    public double? Landarea { get; set; }

    [Column("BUILDING_AREA")]
    public double? BuildingArea { get; set; }

    [Column("FLOOR_NUM")]
    public int? FloorNum { get; set; }

    [Column("GROUND_FLOOR_NUM")]
    public int? GroundFloorNum { get; set; }

    [Column("BASEMENT_FLOOR_NUM")]
    public int? BasementFloorNum { get; set; }

    [Column("BUILDING_HEIGHT")]
    public double? BuildingHeight { get; set; }

    [Column("GROUND_HEIGHT")]
    public double? GroundHeight { get; set; }

    [Column("BASEMENT_HEIGHT")]
    public double? BasementHeight { get; set; }

    [Column("PACKING_NUM")]
    public int? PackingNum { get; set; }

    [Column("INNER_PACKING_NUM")]
    public int? InnerPackingNum { get; set; }

    [Column("OUTER_PACKING_NUM")]
    public int? OuterPackingNum { get; set; }

    [Column("ELECTRIC_CAPACITY")]
    public double? ElectricCapacity { get; set; }

    [Column("FAUCET_CAPACITY")]
    public double? FaucetCapacity { get; set; }

    [Column("GENERATION_CAPACITY")]
    public double? GenerationCapacity { get; set; }

    [Column("WATER_CAPACITY")]
    public double? WaterCapacity { get; set; }

    [Column("ELEVWATER_TANK")]
    public double? ElevwaterTank { get; set; }

    [Column("WATER_TANK")]
    public double? WaterTank { get; set; }

    [Column("GAS_CAPACITY")]
    public double? GasCapacity { get; set; }

    [Column("BOILER")]
    public double? Boiler { get; set; }

    [Column("WATER_DISPENSER")]
    public double? WaterDispenser { get; set; }

    [Column("LIFT_NUM")]
    public int? LiftNum { get; set; }

    [Column("PEOPLELIFT_NUM")]
    public int? PeopleliftNum { get; set; }

    [Column("CARGOLIFT_NUM")]
    public int? CargoliftNum { get; set; }

    [Column("COOL_HEAT_CAPACITY")]
    public double? CoolHeatCapacity { get; set; }

    [Column("HEAT_CAPACITY")]
    public double? HeatCapacity { get; set; }

    [Column("COOL_CAPACITY")]
    public double? CoolCapacity { get; set; }

    [Column("LANDSCAPE_AREA")]
    public double? LandscapeArea { get; set; }

    [Column("GROUND_AREA")]
    public double? GroundArea { get; set; }

    [Column("ROOPTOP_AREA")]
    public double? RooptopArea { get; set; }

    [Column("TOILET_NUM")]
    public int? ToiletNum { get; set; }

    [Column("MENTOILET_NUM")]
    public int? MentoiletNum { get; set; }

    [Column("WOMENTOILET_NUM")]
    public int? WomentoiletNum { get; set; }

    [Column("FIRE_RATING")]
    [StringLength(10)]
    [Unicode(false)]
    public string? FireRating { get; set; }

    [Column("SEPTIC_TANK_CAPACITY")]
    public double? SepticTankCapacity { get; set; }

    [Column("DEL_YN")]
    public bool? DelYn { get; set; }

    [Column("CREATE_USER")]
    [StringLength(15)]
    [Unicode(false)]
    public string? CreateUser { get; set; }

    [Column("UPDATE_USER")]
    [StringLength(15)]
    [Unicode(false)]
    public string? UpdateUser { get; set; }

    [Column("DELETE_USER")]
    [StringLength(15)]
    [Unicode(false)]
    public string? DeleteUser { get; set; }

    [Column("CREATE_DT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; }

    [Column("UPDATE_DT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    [Column("DELETE_DT", TypeName = "datetime")]
    public DateTime? DeleteDt { get; set; }

    [Column("PLACEINFO_CODE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? PlaceinfoCode { get; set; }

    [InverseProperty("BuildinginfoCodeNavigation")]
    public virtual ICollection<Energymonthinfo> Energymonthinfos { get; set; } = new List<Energymonthinfo>();

    [InverseProperty("BuildinginfoCodeNavigation")]
    public virtual ICollection<Floorinfo> Floorinfos { get; set; } = new List<Floorinfo>();

    [ForeignKey("PlaceinfoCode")]
    [InverseProperty("Buildinginfos")]
    public virtual Placeinfo? PlaceinfoCodeNavigation { get; set; }

    [InverseProperty("BuildinginfoCodeNavigation")]
    public virtual ICollection<RoomInventory> RoomInventories { get; set; } = new List<RoomInventory>();

    [InverseProperty("BuildinginfoCodeNavigation")]
    public virtual ICollection<Subitem> Subitems { get; set; } = new List<Subitem>();

    [InverseProperty("BuildinginfoCodeNavigation")]
    public virtual ICollection<TotalInventory> TotalInventories { get; set; } = new List<TotalInventory>();
}
