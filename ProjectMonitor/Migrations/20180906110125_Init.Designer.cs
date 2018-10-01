﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMonitor.Models;

namespace ProjectMonitor.Migrations
{
    [DbContext(typeof(ProjectMonitorContext))]
    [Migration("20180906110125_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectMonitor.Models.Cooling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cycles");

                    b.Property<int>("Duration");

                    b.Property<int>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Cooling");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Denaturation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cycles");

                    b.Property<int>("Duration");

                    b.Property<int>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Denaturation");
                });

            modelBuilder.Entity("ProjectMonitor.Models.EmployeeRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanAssignTask");

                    b.Property<string>("Name");

                    b.Property<int>("RoleLevel");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdSoyad");

                    b.Property<string>("CepTelefonu");

                    b.Property<DateTime>("DogumTarihi");

                    b.Property<string>("Email");

                    b.Property<int>("EmployeeRoleId");

                    b.Property<string>("EvTelefonu");

                    b.Property<string>("FotografUrl");

                    b.Property<bool>("IsActive");

                    b.Property<string>("IsTelefonu");

                    b.Property<string>("KullaniciAdi");

                    b.Property<string>("Parola");

                    b.Property<long>("Tckn");

                    b.Property<string>("Unvan");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeRoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Enzyme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hacim");

                    b.Property<string>("Kod");

                    b.HasKey("Id");

                    b.ToTable("Enzyme");
                });

            modelBuilder.Entity("ProjectMonitor.Models.MenuItem", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("ChildItemId");

                    b.Property<string>("Icon");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<short>("OperationId");

                    b.Property<int?>("OperationId1");

                    b.Property<short>("OrderNumber");

                    b.Property<short?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ChildItemId");

                    b.HasIndex("OperationId1");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("ProjectMonitor.Models.MixA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hacim");

                    b.Property<string>("Kod");

                    b.HasKey("Id");

                    b.ToTable("MixA");
                });

            modelBuilder.Entity("ProjectMonitor.Models.MixB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hacim");

                    b.Property<string>("Kod");

                    b.HasKey("Id");

                    b.ToTable("MixB");
                });

            modelBuilder.Entity("ProjectMonitor.Models.NucleicAcid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hacim");

                    b.Property<string>("Kod");

                    b.Property<string>("Sonuc");

                    b.HasKey("Id");

                    b.ToTable("NucleicAcid");
                });

            modelBuilder.Entity("ProjectMonitor.Models.OligoNucleotide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AlinmaTarihi");

                    b.Property<string>("BesIsaretleme");

                    b.Property<string>("GcPercent");

                    b.Property<int>("HedefBolgeUzunlugu");

                    b.Property<string>("HedefGenTur");

                    b.Property<string>("KaynakTasarlananSistem");

                    b.Property<int>("NucleotideLength");

                    b.Property<string>("NucleotideSequence");

                    b.Property<string>("OligoNucleotideType");

                    b.Property<string>("PrimerDimertur");

                    b.Property<string>("Self3Comp");

                    b.Property<string>("SelfComp");

                    b.Property<string>("SiparisKodu");

                    b.Property<DateTime?>("SiparisTarihi");

                    b.Property<string>("Tm");

                    b.Property<string>("UcIsaretleme");

                    b.HasKey("Id");

                    b.ToTable("OligoNucleotide");
                });

            modelBuilder.Entity("ProjectMonitor.Models.OligonucleotideInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OligoNucleotideId");

                    b.Property<int>("OligoNucleotideMixBId");

                    b.HasKey("Id");

                    b.HasIndex("OligoNucleotideId");

                    b.HasIndex("OligoNucleotideMixBId");

                    b.ToTable("OligonucleotideInfo");
                });

            modelBuilder.Entity("ProjectMonitor.Models.OligoNucleotideMixB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama");

                    b.Property<DateTime>("HazirlamaTarihi");

                    b.Property<string>("MixBCode");

                    b.HasKey("Id");

                    b.ToTable("OligoNucleotideMixB");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("ProjectMonitor.Models.OperationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<short>("OperationId");

                    b.Property<int?>("OperationId1");

                    b.Property<short>("RoleId");

                    b.Property<int?>("RoleId1");

                    b.HasKey("Id");

                    b.HasIndex("OperationId1");

                    b.HasIndex("RoleId1");

                    b.ToTable("OperationRole");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Pcr1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cycles");

                    b.Property<int>("Duration");

                    b.Property<int>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Pcr1");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Pcr2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cycles");

                    b.Property<int>("Duration");

                    b.Property<int>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Pcr2");
                });

            modelBuilder.Entity("ProjectMonitor.Models.PcrProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CalisanGen");

                    b.Property<string>("CalismaAmaci");

                    b.Property<string>("Cihaz");

                    b.Property<int>("CoolingId");

                    b.Property<int>("DH20");

                    b.Property<int>("DenaturationId");

                    b.Property<int>("EnzymeId");

                    b.Property<string>("KayitAdi");

                    b.Property<int>("MixAId");

                    b.Property<int>("MixBId");

                    b.Property<int>("NucleicAcidId");

                    b.Property<string>("OperatorAdi");

                    b.Property<int>("Pcr1Id");

                    b.Property<int>("Pcr2Id");

                    b.Property<int>("ResultSlipId");

                    b.Property<string>("Results");

                    b.Property<DateTime>("Tarih");

                    b.Property<string>("Yorum");

                    b.HasKey("Id");

                    b.HasIndex("CoolingId");

                    b.HasIndex("DenaturationId");

                    b.HasIndex("EnzymeId");

                    b.HasIndex("MixAId");

                    b.HasIndex("MixBId");

                    b.HasIndex("NucleicAcidId");

                    b.HasIndex("Pcr1Id");

                    b.HasIndex("Pcr2Id");

                    b.HasIndex("ResultSlipId");

                    b.ToTable("PcrProcess");
                });

            modelBuilder.Entity("ProjectMonitor.Models.ProjectResearchPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectStepsId");

                    b.Property<int>("ReferenceArticlesId");

                    b.Property<int>("StepsResearchId");

                    b.Property<int>("WorkItemsId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectStepsId");

                    b.HasIndex("ReferenceArticlesId");

                    b.HasIndex("StepsResearchId");

                    b.HasIndex("WorkItemsId");

                    b.ToTable("ProjectResearchPlan");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeklenenNumuneAdedi");

                    b.Property<string>("IlgiliMusteri");

                    b.Property<string>("IlgiliMusteriEmail");

                    b.Property<string>("IlgiliMusteriTelNo");

                    b.Property<string>("IlgiliMusteriTemsilcisi");

                    b.Property<int>("KullanilacakMesai");

                    b.Property<int>("OligonucleotideInfoId");

                    b.Property<int>("PcrProcessId");

                    b.Property<string>("ProjeAciklama");

                    b.Property<DateTime?>("ProjeBaslangicTarihi");

                    b.Property<DateTime?>("ProjeBitisTarihi");

                    b.Property<string>("ProjeServerLink");

                    b.Property<string>("ProjeSonDurum");

                    b.Property<string>("ProjeSorumlusu");

                    b.Property<string>("ProjeTuru");

                    b.Property<string>("ProjectReport");

                    b.Property<int>("ProjectResearchPlanId");

                    b.Property<int>("ProjectStateId");

                    b.Property<int>("ResultsId");

                    b.Property<int>("SampleExtractionId");

                    b.Property<int>("SampleProviderId");

                    b.Property<int?>("SdfNumber");

                    b.Property<int?>("UhtNumber");

                    b.Property<int>("WorkItemMonitorId");

                    b.HasKey("Id");

                    b.HasIndex("OligonucleotideInfoId");

                    b.HasIndex("PcrProcessId");

                    b.HasIndex("ProjectResearchPlanId");

                    b.HasIndex("ProjectStateId");

                    b.HasIndex("ResultsId");

                    b.HasIndex("SampleExtractionId");

                    b.HasIndex("SampleProviderId");

                    b.HasIndex("WorkItemMonitorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectMonitor.Models.ProjectState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BaslangicTarihi");

                    b.Property<DateTime?>("BitisTarihi");

                    b.Property<int>("CalismaSure");

                    b.Property<int>("KalanSure");

                    b.Property<int>("ProjectRoles");

                    b.Property<int>("SorumluKisiId");

                    b.Property<string>("Status");

                    b.Property<string>("Tamamlanan");

                    b.Property<string>("YardimciKisiler");

                    b.HasKey("Id");

                    b.HasIndex("SorumluKisiId");

                    b.ToTable("ProjectState");
                });

            modelBuilder.Entity("ProjectMonitor.Models.ProjectSteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlananIslem");

                    b.HasKey("Id");

                    b.ToTable("ProjectSteps");
                });

            modelBuilder.Entity("ProjectMonitor.Models.ReferenceArticles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReferansMakaleler");

                    b.HasKey("Id");

                    b.ToTable("ReferenceArticles");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Results", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GorselLinki");

                    b.Property<string>("NanogramDegeri");

                    b.Property<bool>("Onay");

                    b.Property<int>("SampleExtractionId");

                    b.Property<string>("TeslimAlan");

                    b.Property<bool>("TespitDegeri1");

                    b.Property<bool>("TespitDegeri2");

                    b.Property<bool>("TespitDegeri3");

                    b.Property<bool>("TespitDegeri4");

                    b.Property<bool>("TespitDegeri5");

                    b.Property<bool>("TespitDegeri6");

                    b.Property<bool>("TespitDegeri7");

                    b.Property<bool>("TespitDegeri8");

                    b.Property<bool>("TespitDegeri9");

                    b.HasKey("Id");

                    b.HasIndex("SampleExtractionId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("ProjectMonitor.Models.ResultSlip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ResultSlip");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<bool>("ShowInList");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProjectMonitor.Models.RoleOperation", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("OperationId");

                    b.HasKey("RoleId", "OperationId");

                    b.HasIndex("OperationId");

                    b.ToTable("RoleOperation");
                });

            modelBuilder.Entity("ProjectMonitor.Models.SampleExtraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama");

                    b.Property<string>("DiagenNukleikAsidKodu");

                    b.Property<DateTime>("EkstraksiyonTarihi");

                    b.Property<string>("KullanilanKit");

                    b.Property<DateTime>("NumuneAlisTarihi");

                    b.Property<string>("NumuneIsim");

                    b.Property<string>("NumuneKodu");

                    b.Property<string>("NumuneKurum");

                    b.Property<string>("NumuneTuru");

                    b.Property<string>("TeslimAlan");

                    b.Property<string>("TeslimAlinan");

                    b.Property<string>("YapanKisi");

                    b.Property<string>("Yontem");

                    b.HasKey("Id");

                    b.ToTable("SampleExtraction");
                });

            modelBuilder.Entity("ProjectMonitor.Models.SampleProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProviderName");

                    b.HasKey("Id");

                    b.ToTable("SampleProvider");
                });

            modelBuilder.Entity("ProjectMonitor.Models.StepsResearch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Metodlar");

                    b.Property<string>("Referans");

                    b.HasKey("Id");

                    b.ToTable("StepsResearch");
                });

            modelBuilder.Entity("ProjectMonitor.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .HasMaxLength(50);

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHashed");

                    b.Property<string>("PasswordHashedSalt");

                    b.Property<string>("Phone")
                        .HasMaxLength(30);

                    b.Property<short>("RoleId");

                    b.Property<int?>("RoleId1");

                    b.HasKey("Id");

                    b.HasIndex("RoleId1");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectMonitor.Models.UserLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IpAdress");

                    b.Property<string>("Message");

                    b.Property<string>("Page");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLog");
                });

            modelBuilder.Entity("ProjectMonitor.Models.WorkItemMonitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("WorkItemDelivered");

                    b.Property<int>("WorkItemRemaining");

                    b.Property<int>("WorkItemTypeId");

                    b.Property<int>("WorkItemUsed");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemTypeId");

                    b.ToTable("WorkItemMonitor");
                });

            modelBuilder.Entity("ProjectMonitor.Models.WorkItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adedi");

                    b.Property<string>("Birimi");

                    b.Property<string>("ItemName");

                    b.HasKey("Id");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("ProjectMonitor.Models.WorkItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AlimTarihi");

                    b.Property<string>("AlinanKisi");

                    b.Property<string>("Marka");

                    b.Property<string>("TeslimAlan");

                    b.Property<int>("TeslimAlinanAdet");

                    b.Property<int>("WorkItemsId");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemsId");

                    b.ToTable("WorkItemType");
                });

            modelBuilder.Entity("ProjectMonitor.Models.Employees", b =>
                {
                    b.HasOne("ProjectMonitor.Models.EmployeeRoles", "EmployeeRole")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.MenuItem", b =>
                {
                    b.HasOne("ProjectMonitor.Models.MenuItem", "ChildItem")
                        .WithMany("MenuChildrenItems")
                        .HasForeignKey("ChildItemId");

                    b.HasOne("ProjectMonitor.Models.Operation", "Operation")
                        .WithMany("MenuItems")
                        .HasForeignKey("OperationId1");
                });

            modelBuilder.Entity("ProjectMonitor.Models.OligonucleotideInfo", b =>
                {
                    b.HasOne("ProjectMonitor.Models.OligoNucleotide", "OligoNucleotide")
                        .WithMany("OligonucleotideInfo")
                        .HasForeignKey("OligoNucleotideId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.OligoNucleotideMixB", "OligoNucleotideMixB")
                        .WithMany("OligonucleotideInfo")
                        .HasForeignKey("OligoNucleotideMixBId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.OperationRole", b =>
                {
                    b.HasOne("ProjectMonitor.Models.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId1");

                    b.HasOne("ProjectMonitor.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId1");
                });

            modelBuilder.Entity("ProjectMonitor.Models.PcrProcess", b =>
                {
                    b.HasOne("ProjectMonitor.Models.Cooling", "Cooling")
                        .WithMany("PcrProcess")
                        .HasForeignKey("CoolingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.Denaturation", "Denaturation")
                        .WithMany("PcrProcess")
                        .HasForeignKey("DenaturationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.Enzyme", "Enzyme")
                        .WithMany("PcrProcess")
                        .HasForeignKey("EnzymeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.MixA", "MixA")
                        .WithMany("PcrProcess")
                        .HasForeignKey("MixAId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.MixB", "MixB")
                        .WithMany("PcrProcess")
                        .HasForeignKey("MixBId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.NucleicAcid", "NucleicAcid")
                        .WithMany("PcrProcess")
                        .HasForeignKey("NucleicAcidId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.Pcr1", "Pcr1")
                        .WithMany("PcrProcess")
                        .HasForeignKey("Pcr1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.Pcr2", "Pcr2")
                        .WithMany("PcrProcess")
                        .HasForeignKey("Pcr2Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.ResultSlip", "ResultSlip")
                        .WithMany("PcrProcess")
                        .HasForeignKey("ResultSlipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.ProjectResearchPlan", b =>
                {
                    b.HasOne("ProjectMonitor.Models.ProjectSteps", "ProjectSteps")
                        .WithMany("ProjectResearchPlan")
                        .HasForeignKey("ProjectStepsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.ReferenceArticles", "ReferenceArticles")
                        .WithMany("ProjectResearchPlan")
                        .HasForeignKey("ReferenceArticlesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.StepsResearch", "StepsResearch")
                        .WithMany("ProjectResearchPlan")
                        .HasForeignKey("StepsResearchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.WorkItems", "WorkItems")
                        .WithMany("ProjectResearchPlan")
                        .HasForeignKey("WorkItemsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.Projects", b =>
                {
                    b.HasOne("ProjectMonitor.Models.OligonucleotideInfo", "OligonucleotideInfo")
                        .WithMany("Projects")
                        .HasForeignKey("OligonucleotideInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.PcrProcess", "PcrProcess")
                        .WithMany("Projects")
                        .HasForeignKey("PcrProcessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.ProjectResearchPlan", "ProjectResearchPlan")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectResearchPlanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.ProjectState", "ProjectState")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectStateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.Results", "Results")
                        .WithMany("Projects")
                        .HasForeignKey("ResultsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.SampleExtraction", "SampleExtraction")
                        .WithMany("Projects")
                        .HasForeignKey("SampleExtractionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.SampleProvider", "SampleProvider")
                        .WithMany("Projects")
                        .HasForeignKey("SampleProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.WorkItemMonitor", "WorkItemMonitor")
                        .WithMany("Projects")
                        .HasForeignKey("WorkItemMonitorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.ProjectState", b =>
                {
                    b.HasOne("ProjectMonitor.Models.Employees", "SorumluKisi")
                        .WithMany()
                        .HasForeignKey("SorumluKisiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.Results", b =>
                {
                    b.HasOne("ProjectMonitor.Models.SampleExtraction", "Sample")
                        .WithMany()
                        .HasForeignKey("SampleExtractionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.RoleOperation", b =>
                {
                    b.HasOne("ProjectMonitor.Models.Operation", "Operation")
                        .WithMany("RoleOperations")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectMonitor.Models.Role", "Role")
                        .WithMany("RoleOperations")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.User", b =>
                {
                    b.HasOne("ProjectMonitor.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId1");
                });

            modelBuilder.Entity("ProjectMonitor.Models.UserLog", b =>
                {
                    b.HasOne("ProjectMonitor.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.WorkItemMonitor", b =>
                {
                    b.HasOne("ProjectMonitor.Models.WorkItemType", "WorkItemType")
                        .WithMany("WorkItemMonitor")
                        .HasForeignKey("WorkItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectMonitor.Models.WorkItemType", b =>
                {
                    b.HasOne("ProjectMonitor.Models.WorkItems", "WorkItems")
                        .WithMany("WorkItemType")
                        .HasForeignKey("WorkItemsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
