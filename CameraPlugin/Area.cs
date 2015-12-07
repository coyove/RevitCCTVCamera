using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace CameraPlugin
{
    class Area
    {
        public static double calc(PointF[] pfs)
        {
            int i, j;
            double area = 0;

            for (i = 0; i < pfs.Length; i++)
            {
                j = (i + 1) % pfs.Length;

                area += pfs[i].X * pfs[j].Y;
                area -= pfs[i].Y * pfs[j].X;
            }

            area /= 2;
            return (area < 0 ? -area : area);
        }

        public static XYZ max(XYZ p1, XYZ p2)
        {
            double retx = p1.X;
            double rety = p1.Y;
            double retz = p1.Z;

            if (p2.X > p1.X) retx = p2.X;
            if (p2.Y > p1.Y) rety = p2.Y;
            if (p2.Z > p1.Z) retz = p2.Z;

            return new XYZ(retx, rety, retz);
        }

        public static XYZ min(XYZ p1, XYZ p2)
        {
            double retx = p1.X;
            double rety = p1.Y;
            double retz = p1.Z;

            if (p2.X < p1.X) retx = p2.X;
            if (p2.Y < p1.Y) rety = p2.Y;
            if (p2.Z < p1.Z) retz = p2.Z;

            return new XYZ(retx, rety, retz);
        }
    }

    public static class ParameterUnitConverter
    {
        private const double METERS_IN_FEET = 0.3048;

        public static double AsProjectUnitTypeDouble(
          this Parameter param)
        {
            if (param.StorageType != StorageType.Double)
                throw new NotSupportedException(
                  "Parameter does not have double value");

            double imperialValue = param.AsDouble();

            Document document = param.Element.Document;

            UnitType ut = ConvertParameterTypeToUnitType(
              param.Definition.ParameterType);

            FormatOptions fo = document.GetUnits().GetFormatOptions(ut);
            
            DisplayUnitType dut = fo.DisplayUnits;

            // Unit Converter
            // http://www.asknumbers.com

            switch (dut)
            {
                #region Length

                case DisplayUnitType.DUT_METERS:
                    return imperialValue * METERS_IN_FEET; //feet
                case DisplayUnitType.DUT_CENTIMETERS:
                    return imperialValue * METERS_IN_FEET * 100;
                case DisplayUnitType.DUT_DECIMAL_FEET:
                    return imperialValue;
                case DisplayUnitType.DUT_DECIMAL_INCHES:
                    return imperialValue * 12;
                case DisplayUnitType.DUT_METERS_CENTIMETERS:
                    return imperialValue * METERS_IN_FEET; //feet
                case DisplayUnitType.DUT_MILLIMETERS:
                    return imperialValue * METERS_IN_FEET * 1000;

                #endregion // Length

                #region Area

                case DisplayUnitType.DUT_SQUARE_FEET:
                    return imperialValue;
                case DisplayUnitType.DUT_ACRES:
                    return imperialValue * 1 / 43560.039;
                case DisplayUnitType.DUT_HECTARES:
                    return imperialValue * 1 / 107639.104;
                case DisplayUnitType.DUT_SQUARE_CENTIMETERS:
                    return imperialValue * Math.Pow(METERS_IN_FEET * 100, 2);
                case DisplayUnitType.DUT_SQUARE_INCHES:
                    return imperialValue * Math.Pow(12, 2);
                case DisplayUnitType.DUT_SQUARE_METERS:
                    return imperialValue * Math.Pow(METERS_IN_FEET, 2);
                case DisplayUnitType.DUT_SQUARE_MILLIMETERS:
                    return imperialValue * Math.Pow(METERS_IN_FEET * 1000, 2);

                #endregion // Area

                #region Volume
                case DisplayUnitType.DUT_CUBIC_FEET:
                    return imperialValue;
                case DisplayUnitType.DUT_CUBIC_CENTIMETERS:
                    return imperialValue * Math.Pow(METERS_IN_FEET * 100, 3);
                case DisplayUnitType.DUT_CUBIC_INCHES:
                    return imperialValue * Math.Pow(12, 3);
                case DisplayUnitType.DUT_CUBIC_METERS:
                    return imperialValue * Math.Pow(METERS_IN_FEET, 3);
                case DisplayUnitType.DUT_CUBIC_MILLIMETERS:
                    return imperialValue * Math.Pow(METERS_IN_FEET * 1000, 3);
                case DisplayUnitType.DUT_CUBIC_YARDS:
                    return imperialValue * 1 / Math.Pow(3, 3);
                case DisplayUnitType.DUT_GALLONS_US:
                    return imperialValue * 7.5;
                case DisplayUnitType.DUT_LITERS:
                    return imperialValue * 28.31684;

                #endregion // Volume

                default:
                    break;
            }

            throw new NotSupportedException();
        }

        public static double AsMetersValue(
          this Parameter param)
        {
            if (param.StorageType != StorageType.Double)
                throw new NotSupportedException(
                  "Parameter does not have double value");

            double imperialValue = param.AsDouble();

            UnitType ut = ConvertParameterTypeToUnitType(
              param.Definition.ParameterType);

            switch (ut)
            {
                case UnitType.UT_Length:
                    return imperialValue * METERS_IN_FEET;

                case UnitType.UT_Area:
                    return imperialValue * Math.Pow(
                      METERS_IN_FEET, 2);

                case UnitType.UT_Volume:
                    return imperialValue * Math.Pow(
                      METERS_IN_FEET, 3);
            }
            throw new NotSupportedException();
        }

        public static UnitType
          ConvertParameterTypeToUnitType(
            ParameterType parameterType)
        {
            if (_map_parameter_type_to_unit_type.ContainsKey(
              parameterType))
            {
                return _map_parameter_type_to_unit_type[
                  parameterType];
            }
            else
            {
                // If we made it this far, there's 
                // no entry in the dictionary.

                throw new ArgumentException(
                  "Cannot convert ParameterType '"
                    + parameterType.ToString()
                    + "' to a UnitType.");
            }
        }

        static Dictionary<ParameterType, UnitType>
          _map_parameter_type_to_unit_type
            = new Dictionary<ParameterType, UnitType>()
        {
    // This data could come from a file, 
    // or (better yet) from Revit itself...
 
    {ParameterType.Angle, UnitType.UT_Angle},
    {ParameterType.Area, UnitType.UT_Area},
    {ParameterType.AreaForce, UnitType.UT_AreaForce},
    {ParameterType.AreaForcePerLength, UnitType.UT_AreaForcePerLength},
    //map.Add(UnitType.UT_AreaForceScale, ParameterType.???);
    {ParameterType.ColorTemperature, UnitType.UT_Color_Temperature},
    {ParameterType.Currency, UnitType.UT_Currency},
    //map.Add(UnitType.UT_DecSheetLength, ParameterType.???);
    {ParameterType.ElectricalApparentPower, UnitType.UT_Electrical_Apparent_Power},
    {ParameterType.ElectricalCurrent, UnitType.UT_Electrical_Current},
    {ParameterType.ElectricalEfficacy, UnitType.UT_Electrical_Efficacy},
    {ParameterType.ElectricalFrequency, UnitType.UT_Electrical_Frequency},
    {ParameterType.ElectricalIlluminance, UnitType.UT_Electrical_Illuminance},
    {ParameterType.ElectricalLuminance, UnitType.UT_Electrical_Luminance},
    {ParameterType.ElectricalLuminousFlux, UnitType.UT_Electrical_Luminous_Flux},
    {ParameterType.ElectricalLuminousIntensity, UnitType.UT_Electrical_Luminous_Intensity},
    {ParameterType.ElectricalPotential, UnitType.UT_Electrical_Potential},
    {ParameterType.ElectricalPower, UnitType.UT_Electrical_Power},
    {ParameterType.ElectricalPowerDensity, UnitType.UT_Electrical_Power_Density},
    {ParameterType.ElectricalWattage, UnitType.UT_Electrical_Wattage},
    {ParameterType.Force, UnitType.UT_Force},
    {ParameterType.ForceLengthPerAngle, UnitType.UT_ForceLengthPerAngle},
    {ParameterType.ForcePerLength, UnitType.UT_ForcePerLength},
    //map.Add(UnitType.UT_ForceScale, ParameterType.???);
    {ParameterType.HVACAirflow, UnitType.UT_HVAC_Airflow},
    {ParameterType.HVACAirflowDensity, UnitType.UT_HVAC_Airflow_Density},
    {ParameterType.HVACAirflowDividedByCoolingLoad, UnitType.UT_HVAC_Airflow_Divided_By_Cooling_Load},
    {ParameterType.HVACAirflowDividedByVolume, UnitType.UT_HVAC_Airflow_Divided_By_Volume},
    {ParameterType.HVACAreaDividedByCoolingLoad, UnitType.UT_HVAC_Area_Divided_By_Cooling_Load},
    {ParameterType.HVACAreaDividedByHeatingLoad, UnitType.UT_HVAC_Area_Divided_By_Heating_Load},
    {ParameterType.HVACCoefficientOfHeatTransfer, UnitType.UT_HVAC_CoefficientOfHeatTransfer},
    {ParameterType.HVACCoolingLoad, UnitType.UT_HVAC_Cooling_Load},
    {ParameterType.HVACCoolingLoadDividedByArea, UnitType.UT_HVAC_Cooling_Load_Divided_By_Area},
    {ParameterType.HVACCoolingLoadDividedByVolume, UnitType.UT_HVAC_Cooling_Load_Divided_By_Volume},
    {ParameterType.HVACCrossSection, UnitType.UT_HVAC_CrossSection},
    {ParameterType.HVACDensity, UnitType.UT_HVAC_Density},
    {ParameterType.HVACDuctSize, UnitType.UT_HVAC_DuctSize},
    {ParameterType.HVACEnergy, UnitType.UT_HVAC_Energy},
    {ParameterType.HVACFactor, UnitType.UT_HVAC_Factor},
    {ParameterType.HVACFriction, UnitType.UT_HVAC_Friction},
    {ParameterType.HVACHeatGain, UnitType.UT_HVAC_HeatGain},
    {ParameterType.HVACHeatingLoad, UnitType.UT_HVAC_Heating_Load},
    {ParameterType.HVACHeatingLoadDividedByArea, UnitType.UT_HVAC_Heating_Load_Divided_By_Area},
    {ParameterType.HVACHeatingLoadDividedByVolume, UnitType.UT_HVAC_Heating_Load_Divided_By_Volume},
    {ParameterType.HVACPower, UnitType.UT_HVAC_Power},
    {ParameterType.HVACPowerDensity, UnitType.UT_HVAC_Power_Density},
    {ParameterType.HVACPressure, UnitType.UT_HVAC_Pressure},
    {ParameterType.HVACRoughness, UnitType.UT_HVAC_Roughness},
    {ParameterType.HVACSlope, UnitType.UT_HVAC_Slope},
    {ParameterType.HVACTemperature, UnitType.UT_HVAC_Temperature},
    {ParameterType.HVACVelocity, UnitType.UT_HVAC_Velocity},
    {ParameterType.HVACViscosity, UnitType.UT_HVAC_Viscosity},
    {ParameterType.Length, UnitType.UT_Length},
    {ParameterType.LinearForce, UnitType.UT_LinearForce},
    {ParameterType.LinearForceLengthPerAngle, UnitType.UT_LinearForceLengthPerAngle},
    {ParameterType.LinearForcePerLength, UnitType.UT_LinearForcePerLength},
    // map.Add(UnitType.UT_LinearForceScale, ParameterType.???);
    {ParameterType.LinearMoment, UnitType.UT_LinearMoment},
    // map.Add(UnitType.UT_LinearMomentScale, ParameterType.???);
    {ParameterType.Moment, UnitType.UT_Moment},
    ///map.Add(UnitType.UT_MomentScale, ParameterType.???);
    {ParameterType.Number, UnitType.UT_Number},
    {ParameterType.PipeSize, UnitType.UT_PipeSize},
    {ParameterType.PipingDensity, UnitType.UT_Piping_Density},
    {ParameterType.PipingFlow, UnitType.UT_Piping_Flow},
    {ParameterType.PipingFriction, UnitType.UT_Piping_Friction},
    {ParameterType.PipingPressure, UnitType.UT_Piping_Pressure},
    {ParameterType.PipingRoughness, UnitType.UT_Piping_Roughness},
    {ParameterType.PipingSlope, UnitType.UT_Piping_Slope},
    {ParameterType.PipingTemperature, UnitType.UT_Piping_Temperature},
    {ParameterType.PipingVelocity, UnitType.UT_Piping_Velocity},
    {ParameterType.PipingViscosity, UnitType.UT_Piping_Viscosity},
    {ParameterType.PipingVolume, UnitType.UT_Piping_Volume},
    //map.Add(UnitType.UT_SheetLength, ParameterType.???);
    //map.Add(UnitType.UT_SiteAngle, ParameterType.???);
    {ParameterType.Slope, UnitType.UT_Slope},
    {ParameterType.Stress, UnitType.UT_Stress},
    {ParameterType.UnitWeight, UnitType.UT_UnitWeight},
    {ParameterType.Volume, UnitType.UT_Volume},
    {ParameterType.WireSize, UnitType.UT_WireSize},
        };
    }
}
