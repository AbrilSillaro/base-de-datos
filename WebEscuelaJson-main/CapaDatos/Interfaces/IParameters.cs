

namespace CapaDatos
{
    public interface IParameters
    {
        void ParameterAddVarChar(string name, string Value);
        void ParameterAddInt(string name, int Value);
        void ParameterAddBool(string name, bool Value);
        void ParameterAddDateTime(string Name, System.DateTime Value);
        void ParameterAddFloat(string Name, double Value);
    }
}
