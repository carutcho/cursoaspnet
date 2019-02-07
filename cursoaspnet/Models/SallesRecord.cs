using System;
using cursoaspnet.Models.Enums;

namespace cursoaspnet.Models {

    public class SallesRecord {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SalleStatusEnum Status { get; set; }
        public Seller Seller { get; set; }


        public SallesRecord() {

        }

        public SallesRecord(int id, DateTime date, double amount, SalleStatusEnum status, Seller seller) {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
