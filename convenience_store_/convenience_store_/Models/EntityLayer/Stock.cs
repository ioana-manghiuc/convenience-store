﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models
{
    public class Stock: BasePropertyChanged
    {
        // ID, ProductID, Quantity, UnitOfMeasurement, SupplyDate, BasePrice, SellingPrice, IsActive

        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        private int productId;
        public int ProductID
        {
            get { return productId; }
            set
            {
                productId = value;
                NotifyPropertyChanged("ProductID");
            }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                NotifyPropertyChanged("ProductName");
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }
        
        private string unitOfMeasurement;
        public string UnitOfMeasurement
        {
            get { return unitOfMeasurement; }
            set
            {
                unitOfMeasurement = value;
                NotifyPropertyChanged("UnitOfMeasurement");
            }
        }

        private System.DateTime? supplyDate;
        public System.DateTime? SupplyDate
        {
            get { return supplyDate; }
            set
            {
                supplyDate = value;
                NotifyPropertyChanged("SupplyDate");
            }
        }

        private float basePrince;
        public float BasePrice
        {
            get { return basePrince; }
            set
            {
                basePrince = value;
                NotifyPropertyChanged("BasePrice");
            }
        }

        private float sellingPrice;
        public float SellingPrice
        {
            get { return sellingPrice; }
            set
            {
                sellingPrice = value;
                NotifyPropertyChanged("SellingPrice");
            }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                NotifyPropertyChanged("IsActive");
            }
        }
    }
}
