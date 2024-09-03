using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mundo02.Utilities
{
    public static class QuaternionExtensions
    {
        public static Vector3 ToEulerAngles(this Quaternion quaternion)
        {
            float roll, pitch, yaw;

            // Roll (x-axis rotation)
            float sinr_cosp = 2 * (quaternion.W * quaternion.X + quaternion.Y * quaternion.Z);
            float cosr_cosp = 1 - 2 * (quaternion.X * quaternion.X + quaternion.Y * quaternion.Y);
            roll = (float)Math.Atan2(sinr_cosp, cosr_cosp);

            // Pitch (y-axis rotation)
            float sinp = 2 * (quaternion.W * quaternion.Y - quaternion.Z * quaternion.X);
            if (Math.Abs(sinp) >= 1)
                pitch = (float)Math.Sign(sinp) * (float)Math.PI / 2; // use 90 degrees if out of range
            else
                pitch = (float)Math.Asin(sinp);

            // Yaw (z-axis rotation)
            float siny_cosp = 2 * (quaternion.W * quaternion.Z + quaternion.X * quaternion.Y);
            float cosy_cosp = 1 - 2 * (quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z);
            yaw = (float)Math.Atan2(siny_cosp, cosy_cosp);

            // Convert radians to degrees and normalize to [0, 360)
            roll = NormalizeAngle(roll);
            pitch = NormalizeAngle(pitch);
            yaw = NormalizeAngle(yaw);

            return new Vector3(roll, pitch, yaw);
        }

        private static float NormalizeAngle(float angle)
        {
            float degrees = MathHelper.ToDegrees(angle);
            degrees = (degrees + 360) % 360; // Normalize to [0, 360)
            return degrees;

        }
    }

}
