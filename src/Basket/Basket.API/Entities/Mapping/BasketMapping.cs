using AutoMapper;
using EventBusRabbitMQ.Events;
 

namespace Basket.API.Entities.Mapping
{
    public class BasketMapping:Profile
    {

        public BasketMapping()
        {

            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();

        }



        
    }
}
