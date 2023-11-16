using DateAccess.Models;

namespace Garaje.Models
{
    public class CarCartViewModel
    {
        //Модель машини для відображення обраної машини на View
        public Car? Car { get; set; }
        
        //Показуватиме інформацію, чи машина уже вибрана у корзині
        public bool IsCarChoose { get; set; }
    }
}
