﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ADJ.BusinessService.Core;
using ADJ.BusinessService.Validators;
using ADJ.DataModel;
using ADJ.DataModel.Core;
using ADJ.DataModel.OrderTrack;
using AutoMapper;
using DTOs;

namespace ADJ.BusinessService.Dtos
{
    public class ProgressCheckDto : EntityDtoBase, ICreateMapping
    {
        [Display(Name = "PO Number")]
        public string PONumber { get; set; }
        [Display(Name = "PO Quantity")]
        public float POQuantity { get; set; }
        [Display(Name = "PO Check Quantity")]
        public float EstQtyToShip { get; set; }
        [Display(Name = "PO Ship Date")]
        public DateTime ShipDate { get; set; }
        public List<OrderDetail> ListOrderDetail { get; set; }
        [Display(Name = "Inspection Date")]
        [InspectionDateValidation("IntendedShipDate")]
        public DateTime InspectionDate { get; set; }
        [Display(Name = "Int Ship Date")]
        [IntShipDateLaterThanInspectionDate("InspectionDate")]
        public DateTime IntendedShipDate { get; set; }
        [Display(Name = "PO Quantity Complete ")]
        public bool Complete { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }
        public bool OnSchedule { get; set; }
        public int OrderId { get; set; }
        public string Supplier { get; set; }
        public string Factory { get; set; }
        public string Origin { get; set; }
        public string OriginPort { get; set; }

        public void CreateMapping(Profile profile)
        {
            profile.CreateMap<ProgressCheck, ProgressCheckDto>().IncludeBase<EntityBase, EntityDtoBase>();
            profile.CreateMap<ProgressCheckDto, ProgressCheck>().IncludeBase<EntityDtoBase, EntityBase>();
        }
    }
    public class GetItemSearchDto : EntityDtoBase
    {
        public List<string> Origins { get; set; }
        public List<string> OriginPorts { get; set; }
        public List<string> Factories { get; set; }
        public List<string> Suppliers { get; set; }
        public List<string> Status { get; set; }
        public List<string> Depts { get; set; }
        
    }
    public class OrderDetailDto_Progress : EntityDtoBase, ICreateMapping
    {
        public string ItemNumber { get; set; }

        public string Line { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(30)]
        public string Warehouse { get; set; }

        [StringLength(30)]
        public string Colour { get; set; }

        [StringLength(30)]
        public string Size { get; set; }

        public string Item { get; set; }

        [Required]
        public float Quantity { get; set; }

        public float ReviseQuantity { get; set; }

        [Required]
        public float Cartons { get; set; }

        [Required]
        public float Cube { get; set; }

        [Required]
        public float KGS { get; set; }

        [Required]
        public float UnitPrice { get; set; }

        public float TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

        [Required]
        public float RetailPrice { get; set; }

        public float TotalRetailPrice
        {
            get
            {
                return Quantity * RetailPrice;
            }
        }

        public string Tariff { get; set; }

        [Required]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public void CreateMapping(Profile profile)
        {
            profile.CreateMap<OrderDetailDto_Progress,OrderDetail>().IncludeBase<EntityBase, EntityDtoBase>();
            profile.CreateMap<OrderDetail,OrderDetailDto_Progress>().IncludeBase<EntityDtoBase, EntityBase>();
        }
    }
}
