namespace NakoShop.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class UpdateCargoDeatilDto
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
