﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MealFridge.Models
{
    public partial class MealFridgeDbContext : DbContext
    {
        public MealFridgeDbContext()
        {
        }

        public MealFridgeDbContext(DbContextOptions<MealFridgeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diet> Diets { get; set; }
        public virtual DbSet<Fridge> Fridges { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Recipeingred> Recipeingreds { get; set; }
        public virtual DbSet<Restriction> Restrictions { get; set; }
        public virtual DbSet<Savedrecipe> Savedrecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Diet>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__DIET__46A222CD03E7D8C3");

                entity.ToTable("DIET");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("account_id");

                entity.Property(e => e.Diet1)
                    .HasMaxLength(64)
                    .HasColumnName("diet");
            });

            modelBuilder.Entity<Fridge>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.IngredId })
                    .HasName("PK__FRIDGE__9100B6D119A3D9F6");

                entity.ToTable("FRIDGE");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("account_id");

                entity.Property(e => e.IngredId).HasColumnName("ingred_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NeededAmount).HasColumnName("needed_amount");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Shopping).HasColumnName("shopping");

                entity.HasOne(d => d.Ingred)
                    .WithMany(p => p.Fridges)
                    .HasForeignKey(d => d.IngredId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fridge_FK_Ingred");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("INGREDIENTS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Aisle)
                    .HasMaxLength(255)
                    .HasColumnName("aisle");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Carbs).HasColumnName("carbs");

                entity.Property(e => e.Cholesterol).HasColumnName("cholesterol");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NetCarbs).HasColumnName("net_carbs");

                entity.Property(e => e.Protein).HasColumnName("protein");

                entity.Property(e => e.SatFat).HasColumnName("sat_fat");

                entity.Property(e => e.ServingSize).HasColumnName("serving_size");

                entity.Property(e => e.ServingUnit)
                    .HasMaxLength(255)
                    .HasColumnName("serving_unit");

                entity.Property(e => e.Sodium).HasColumnName("sodium");

                entity.Property(e => e.Sugar).HasColumnName("sugar");

                entity.Property(e => e.TotalFat).HasColumnName("total_fat");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.Day })
                    .HasName("PK__MEAL__4B255BFFFEC60192");

                entity.ToTable("MEAL");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("account_id");

                entity.Property(e => e.Day)
                    .HasColumnType("datetime")
                    .HasColumnName("day");

                entity.Property(e => e.Meal1)
                    .HasMaxLength(255)
                    .HasColumnName("meal");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("Meal_FK_Recipe");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("RECIPES");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Breakfast).HasColumnName("breakfast");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Carbs).HasColumnName("carbs");

                entity.Property(e => e.Cholesterol).HasColumnName("cholesterol");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.Dessert).HasColumnName("dessert");

                entity.Property(e => e.Dinner).HasColumnName("dinner");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Instructions)
                    .HasMaxLength(255)
                    .HasColumnName("instructions");

                entity.Property(e => e.Lunch).HasColumnName("lunch");

                entity.Property(e => e.Minutes).HasColumnName("minutes");

                entity.Property(e => e.NetCarbs).HasColumnName("net_carbs");

                entity.Property(e => e.Protein).HasColumnName("protein");

                entity.Property(e => e.SatFat).HasColumnName("sat_fat");

                entity.Property(e => e.ServingSize).HasColumnName("serving_size");

                entity.Property(e => e.ServingUnit)
                    .HasMaxLength(255)
                    .HasColumnName("serving_unit");

                entity.Property(e => e.Servings).HasColumnName("servings");

                entity.Property(e => e.Snack).HasColumnName("snack");

                entity.Property(e => e.Sodium).HasColumnName("sodium");

                entity.Property(e => e.Sugar).HasColumnName("sugar");

                entity.Property(e => e.Summery)
                    .HasMaxLength(255)
                    .HasColumnName("summery");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.TotalFat).HasColumnName("total_fat");
            });

            modelBuilder.Entity<Recipeingred>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.IngredId })
                    .HasName("PK__RECIPEIN__E2D379870B6D20E0");

                entity.ToTable("RECIPEINGRED");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.IngredId).HasColumnName("ingred_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Carbs).HasColumnName("carbs");

                entity.Property(e => e.Cholesterol).HasColumnName("cholesterol");

                entity.Property(e => e.Direction)
                    .HasMaxLength(255)
                    .HasColumnName("direction");

                entity.Property(e => e.NetCarbs).HasColumnName("net_carbs");

                entity.Property(e => e.Protein).HasColumnName("protein");

                entity.Property(e => e.SatFat).HasColumnName("sat_fat");

                entity.Property(e => e.ServingUnit)
                    .HasMaxLength(255)
                    .HasColumnName("serving_unit");

                entity.Property(e => e.Sodium).HasColumnName("sodium");

                entity.Property(e => e.Sugar).HasColumnName("sugar");

                entity.Property(e => e.TotalFat).HasColumnName("total_fat");

                entity.HasOne(d => d.Ingred)
                    .WithMany(p => p.Recipeingreds)
                    .HasForeignKey(d => d.IngredId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RecipeIngred_FK_Ingred");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Recipeingreds)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RecipeIngred_FK_Recipe");
            });

            modelBuilder.Entity<Restriction>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.IngredId })
                    .HasName("PK__RESTRICT__9100B6D117EB3716");

                entity.ToTable("RESTRICTIONS");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("account_id");

                entity.Property(e => e.IngredId).HasColumnName("ingred_id");

                entity.Property(e => e.Banned).HasColumnName("banned");

                entity.Property(e => e.Dislike).HasColumnName("dislike");

                entity.HasOne(d => d.Ingred)
                    .WithMany(p => p.Restrictions)
                    .HasForeignKey(d => d.IngredId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Restrictions_FK_Ingred");
            });

            modelBuilder.Entity<Savedrecipe>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.RecipeId })
                    .HasName("PK__SAVEDREC__E5F53C145B8F9965");

                entity.ToTable("SAVEDRECIPES");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(255)
                    .HasColumnName("account_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.Favorited).HasColumnName("favorited");

                entity.Property(e => e.Shelved).HasColumnName("shelved");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Savedrecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SavedRecipes_FK_Recipes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
