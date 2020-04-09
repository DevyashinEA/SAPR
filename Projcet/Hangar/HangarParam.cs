using System;

namespace Hangar
{
    /// <summary>
    /// Класс HangarParam хранит параметры ангара.
    /// </summary>
    public class HangarParam
    {
        /// <summary>
        /// Высота ангара.
        /// </summary>
        private double _hangarHeight;
        /// <summary>
        /// Ширина ангара.
        /// </summary>
        private double _hangarWidth;
        /// <summary>
        /// Высота ангара
        /// </summary>
        private double _hangarLendth;
        /// <summary>
        /// Высота ворот
        /// </summary>
        private double _gateHeight;
        /// <summary>
        /// Ширина ворот
        /// </summary>
        private double _gateWidth;
        /// <summary>
        /// Высота стены(подошвы фундамента)
        /// </summary>
        private double _wallHeight;
        /// <summary>
        /// Первый слой грунта
        /// </summary>
        private Soil _firstSoil = new Soil();
        /// <summary>
        /// Второй слой грунта
        /// </summary>
        private Soil _secondSoil = new Soil();
        /// <summary>
        /// Третий слой грунта
        /// </summary>
        private Soil _thirdSoil = new Soil();

        /// <summary>
        /// Возвращает и задаёт высоту ангара с ограничением 2..10 метров
        /// </summary>
        public double HangarHeight
        {
            get
            {
                return _hangarHeight;
            }
            set
            {
                if (value <= 10 && value >= 2)
                    _hangarHeight = value;
                else
                    throw new ArgumentException("Высота ангара не может быть меньше 2м или больше 10м.");
            }
        }

        /// <summary>
        /// Возвращает и задаёт ширину ангара с ограничением 2..14 метров
        /// </summary>
        public double HangarWidth
        {
            get
            {
                return _hangarWidth;
            }
            set
            {
                if (value <= 14 && value >= 2)
                    _hangarWidth = value;
                else
                    throw new ArgumentException("Ширина ангара не может быть меньше 2м или больше 14м.");
            }
        }

        /// <summary>
        /// Возвращает и задаёт длину ангара с ограничением 2..40 метров
        /// </summary>
        public double HangarLength
        {
            get
            {
                return _hangarLendth;
            }
            set
            {
                if (value <= 40 && value >= 2)
                    _hangarLendth = value;
                else
                    throw new ArgumentException("Длина ангара не может быть меньше 2м или больше 40м.");
            }
        }

        /// <summary>
        /// Возвращает и задаёт высоту ворот с ограничением 2..(высота ангара) метров
        /// </summary>
        public double GateHeight
        {
            get
            {
                return _gateHeight;
            }
            set
            {
                if (value <= HangarHeight && value >= 2)
                    _gateHeight = value;
                else
                    throw new ArgumentException("Высота ворот не может быть меньше 2м или больше " + HangarHeight + "м.");
            }
        }

        /// <summary>
        /// Возвращает и задаёт ширину ворот с ограничением (Ширина ангара 25%) ..(Ширина ангара 50%) метров
        /// </summary>
        public double GateWidth
        {
            get
            {
                return _gateWidth;
            }
            set
            {
                if (value <= HangarWidth / 2 && value >= HangarWidth / 4)
                    _gateWidth = value;
                else
                    throw new ArgumentException("Ширина ворот не может быть меньше " + HangarWidth / 4 + "м или больше " + HangarWidth / 2 + "м.");
            }
        }

        /// <summary>
        /// Возвращает и задаёт высоту стен (подошвы) с ограничением 0.1..0.3 метров
        /// </summary>
        public double WallHeight
        {
            get
            {
                return _wallHeight;
            }
            set
            {
                if (value <= 0.3 && value >= 0.1)
                    _wallHeight = value;
                else
                    throw new ArgumentException("Высота стена не может быть меньше 0.1м или больше 0.3м.");
            }
        }

        /// <summary>
        /// Возвращает и задаёт первый слой грунта
        /// </summary>
        public Soil FirstSoil
        {
            get
            {
                return _firstSoil;
            }
            set
            {
                _firstSoil = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт второй слой грунта
        /// </summary>
        public Soil SecondSoil
        {
            get
            {
                return _secondSoil;
            }
            set
            {
                _secondSoil = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт третий слой грунта
        /// </summary>
        public Soil ThirdSoil
        {
            get
            {
                return _thirdSoil;
            }
            set
            {
                _thirdSoil = value;
            }
        }
    }
}
