namespace Data.DatabaseModels.CompleteModel
{
    using System.Data.Entity;

    public partial class CompleteModel : DbContext
    {
        public CompleteModel()
            : base("name=CompleteModel")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Clubs_Emails> Clubs_Emails { get; set; }
        public virtual DbSet<Clubs_PhoneNumbers> Clubs_PhoneNumbers { get; set; }
        public virtual DbSet<Clubs_Users_UserRoles_Junctions> Clubs_Users_UserRoles_Junctions { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<RaceEvent> RaceEvents { get; set; }
        public virtual DbSet<RaceEvents_Users_UserRoles_Junctions> RaceEvents_Users_UserRoles_Junctions { get; set; }
        public virtual DbSet<Regatta> Regattas { get; set; }
        public virtual DbSet<Regattas_Users_UserRoles_Junctions> Regattas_Users_UserRoles_Junctions { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public virtual DbSet<RegisteredUsers_SocialEvents> RegisteredUsers_SocialEvents { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<SocialEvent> SocialEvents { get; set; }
        public virtual DbSet<SocialEvents_Users_UserRoles_Junctions> SocialEvents_Users_UserRoles_Junctions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Teams_RaceEvents> Teams_RaceEvents { get; set; }
        public virtual DbSet<Teams_RegisteredUsers> Teams_RegisteredUsers { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Clubs)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Regattas)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boat>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Boat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Clubs_Emails)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Clubs_PhoneNumbers)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Clubs_Users_UserRoles_Junctions)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Entries)
                .WithOptional(e => e.Club)
                .HasForeignKey(e => e.ClubRepresentationId);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Regattas)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Email>()
                .HasMany(e => e.Clubs_Emails)
                .WithRequired(e => e.Email)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneNumber>()
                .HasMany(e => e.Clubs_PhoneNumbers)
                .WithRequired(e => e.PhoneNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhoneNumber>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.PhoneNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEvent>()
                .HasMany(e => e.RaceEvents_Users_UserRoles_Junctions)
                .WithRequired(e => e.RaceEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEvent>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.RaceEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEvent>()
                .HasMany(e => e.Teams_RaceEvents)
                .WithRequired(e => e.RaceEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.RaceEvents)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.Regattas_Users_UserRoles_Junctions)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.SocialEvents)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(e => e.RegisteredUsers_SocialEvents)
                .WithRequired(e => e.RegisteredUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(e => e.Teams_RegisteredUsers)
                .WithRequired(e => e.RegisteredUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SocialEvent>()
                .HasMany(e => e.RegisteredUsers_SocialEvents)
                .WithRequired(e => e.SocialEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SocialEvent>()
                .HasMany(e => e.SocialEvents_Users_UserRoles_Junctions)
                .WithRequired(e => e.SocialEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Teams_RaceEvents)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Teams_RegisteredUsers)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Clubs_Users_UserRoles_Junctions)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.RaceEvents_Users_UserRoles_Junctions)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Regattas_Users_UserRoles_Junctions)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.SocialEvents_Users_UserRoles_Junctions)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Clubs_Users_UserRoles_Junctions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ResponsibleUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RaceEvents_Users_UserRoles_Junctions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Regattas_Users_UserRoles_Junctions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SocialEvents_Users_UserRoles_Junctions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}