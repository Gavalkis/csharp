using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masterAndFloorApp
{
    public class PartnerService
    {
        private masterAndFloorEntities1 _context;

        public PartnerService()
        {
            _context = masterAndFloorEntities1.GetContext();
        }

        public void CalculateDiscounts()
        {
            var partners = _context.Partners.Include("PartnerProducts").ToList();

            foreach (var partner in partners)
            {
                long totalQuantity = partner.PartnerProducts.Sum(pp => pp.Quantity);
                partner.Discount = CalculateDiscount(totalQuantity); // Устанавливаем значение Discount
            }

            _context.SaveChanges();
        }

        private float CalculateDiscount(long totalQuantity)
        {
            if (totalQuantity < 10000)
                return 0f; // 0% скидка
            else if (totalQuantity < 50000)
                return 5f; // 5% скидка
            else if (totalQuantity < 300000)
                return 10f; // 10% скидка
            else
                return 15f; // 15% скидка
        }
    }
}
