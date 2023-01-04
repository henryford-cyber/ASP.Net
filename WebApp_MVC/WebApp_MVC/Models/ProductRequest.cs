﻿namespace WebApp_MVC.Models
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
    }
}
