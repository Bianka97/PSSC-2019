﻿using GameRentWeb.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameRentWeb.Models
{
    public class Game
    {   
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Cover image")]
        public string CoverImage { get; set; }  // this holds the path to the file
        public string Platform { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; } // this will decrease when an order is made

        #region operations
        public Game RentGame()
        {
            if (Quantity > 0)
            { 
                Quantity--;
                return this;
            }
            else
            {
                return null;
            }   
        }

        public Game ReturnGame()
        {
            Quantity++;
            return this;
        }
        #endregion
        
        #region overrides
        public override bool Equals(object obj)
        {
            var game = (Game)obj;

            if(game != null)
            {
                return (Id == game.Id);
            }
            return false;
        }
        #endregion
    }
}
