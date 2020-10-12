namespace BrickPi3.Utils
{
    public class GearUtils
    {
        private GearUtils joinedParent = null;
        private GearUtils drivenParent = null;

        private int teeths = 0;

        public GearUtils(int teeths)
        {
            this.teeths = teeths;
        }

        public GearUtils Drive(GearUtils gear)
        {
            gear.drivenParent = this;
            return gear;
        }

        public GearUtils Drive(int theets)
        {
            var gear = new GearUtils(theets);
            gear.drivenParent = this;
            return gear;
        }

        public GearUtils Connect(GearUtils gear)
        {
            gear.joinedParent = this;
            return gear;
        }

        public GearUtils Connect(int theets)
        {
            var gear = new GearUtils(theets);
            gear.joinedParent = this;
            return gear;
        }

        public double GetFactor()
        {
            var currentGear = this;
            var currentFactor = 1.0;

            while (currentGear.joinedParent != null || currentGear.drivenParent != null)
            {
                if (currentGear.drivenParent != null)
                {
                    currentFactor *= (double)(-1 * (double)currentGear.drivenParent.teeths / (double)currentGear.teeths);
                    currentGear = currentGear.drivenParent;
                }
                else
                {
                    currentGear = currentGear.joinedParent;
                }
            }

            return currentFactor;
        }
    }
}
