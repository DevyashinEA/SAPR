using System;

namespace Hangar
{
    /// <summary>
    /// Класс хранящий в себе данные о грунте.
    /// </summary>
    public class Soil
    {
        /// <summary>
        /// Тип грунта.
        /// </summary>
        private SoilTypes _soilTypes;
        /// <summary>
        /// Размер слоя грунта.
        /// </summary>
        private double _size;
        /// <summary>
        /// Несущая способность грунта (нагрузка).
        /// </summary>
        private double _load;

        /// <summary>
        /// Возвращает и задаёт тип грунта классу Soil. В зависимости от типа грунта, присваивает значение нагрузки переменной _load.
        /// </summary>
        public SoilTypes SoilTypes
        {
            get
            {
                return _soilTypes;
            }
            set
            {
                _soilTypes = value;
                switch ((int)_soilTypes)
                {
                    case 0:
                        Load = 5;
                        break;
                    case 1:
                        Load = 4;
                        break;
                    case 2:
                        Load = 3;
                        break;
                    case 3:
                        Load = 2;
                        break;
                    case 4:
                        Load = 1.5;
                        break;
                    case 5:
                        Load = 1.5;
                        break;
                    case 6:
                        Load = 4;
                        break;
                    case 7:
                        Load = 1.5;
                        break;
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт размер слоя грунта с ограничением 0.3..5 метров.
        /// </summary>
        public double Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value>= 0.3 && value <= 5)
                    _size = value;
                else
                    throw new ArgumentException("Высота стена не может быть меньше 0.3м или больше 5м.");
            }
        }

        /// <summary>
        /// Возвращает значение нагрузки грунта.
        /// </summary>
        public double Load
        {
            get
            {
                return _load;
            }
            private set
            {
                _load = value;
            }
        }
    }
}
