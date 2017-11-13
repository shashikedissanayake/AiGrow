using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_Location
    {
        public bool insert(AiGrow.Model.ML_Location location)
        {
            return new DL_Location().insert(location);
        }

        public bool delete(AiGrow.Model.ML_Location loaction)
        {
            return new DL_Location().delete(loaction);
        }
    }
}
