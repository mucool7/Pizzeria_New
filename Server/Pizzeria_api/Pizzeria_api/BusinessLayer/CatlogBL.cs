using Pizzeria_api.DataLayer;
using Pizzeria_api.Models;
using Pizzeria_api.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.BusinessLayer
{
    public partial class BusinessLogic
    {

       
        public List<Product> GetProducts(int productNo=0)
        {
            try
            {
                List<Product> products = new List<Product>();
                List<SubPart> subParts = GetSubParts();
                List<Part> Parts = GetParts();
                products = adapter.GetData<List<Product>>(DataPaths.ReadyProduct);

                if(productNo>0)
                products = products.Where(x => x.ProductNo == productNo).ToList();

                foreach (Product product in products)
                {
                    foreach(Part part in product.Parts)
                    {
                        var masterPart = Parts.Where(x => x.PartNo == part.PartNo).FirstOrDefault();

                        part.Name = masterPart.Name;
                        part.IsImage = masterPart.IsImage;


                        if (part.SubTypes != null)
                        {
                            foreach(SubPart subPart in part.SubTypes)
                            {
                                var masterSubPart = subParts.Where(x => x.SubPartNo == subPart.SubPartNo && x.PartNo == subPart.PartNo).SingleOrDefault();
                                subPart.ImagePath = masterSubPart.ImagePath;
                                subPart.Price = masterSubPart.Price;
                                subPart.Name = masterSubPart.Name;
                            }

                           
                        }

                    }
                }
                
                return products;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public void GerenateRandomProducts(int count)
        {
         
            List<Food> Pizza = adapter.GetData<List<Food>>(DataPaths.Pizzas);
            List<Food> Non_Pizza = adapter.GetData<List<Food>>(DataPaths.Non_Pizzas);
            int TotalPizza = Pizza.Count;
            int TotalNon_Pizza = Non_Pizza.Count;
            
            Random rand = new Random(0);
            
            try
            {
                List<Product> products = new List<Product>();
                List<Part> parts = GetParts();
                List<SubPart> subParts = GetSubParts();
                
                for(int i = 1; i <= count; i++ )
                {
                    Product product = new Product();
                    
                    product.ProductNo = i;

                    product.ProductType = rand.Next(1, 3);

                    // Pizza Products which can be customised
                    if (product.ProductType == 1 )
                    {
                        var partCount = rand.Next(0, parts.Count);
                        product.Parts = parts;
                        decimal price = 0;
                        foreach (Part part in product.Parts)
                        {
                            var subp = subParts.Where(x => x.PartNo == part.PartNo).ToList();
                            if (subp.Count > 0)
                            {
                                part.SubTypes = new List<SubPart>();
                                var subCount = rand.Next(0, subp.Count - 1);
                                part.SubTypes.Add(subp[subCount]);

                                price += part.SubTypes.Sum(x => x.Price);
                            }
                        }

                        int pz = rand.Next(0, TotalPizza - 1);

                      
                        product.Name = Pizza[pz].Name;
                        product.Image = Pizza[pz].Img;
                        product.TotalPrice = price;
                    }
                    else 
                    {
                        // Non Pizza products which are no customizable
                        int npz = rand.Next(0, TotalNon_Pizza - 1);
                      
                        product.Name = Non_Pizza[npz].Name;
                        product.Image = Non_Pizza[npz].Img;
                        product.TotalPrice = rand.Next(60,600);
                        product.Parts = new List<Part>();
                    }

                    
                   

                    products.Add(product);
                }

               
                adapter.WriteData(DataPaths.ReadyProduct, products);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
