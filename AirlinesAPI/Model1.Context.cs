﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirlinesAPI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AssignmentDBEntities : DbContext
    {
        public AssignmentDBEntities()
            : base("name=AssignmentDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }
        public virtual DbSet<ReservationDetail> ReservationDetails { get; set; }
        public virtual DbSet<ReservationMaster> ReservationMasters { get; set; }
    }
}