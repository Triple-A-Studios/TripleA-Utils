namespace Utils.TripleA.Extensions
{
	public static class MathfExtension
	{
		public static double Max(double a, double b) {
			return (a > b) ? a : b;
		}

		public static double Max(params double[] values) {
			int num = values.Length;
			if (num == 0) {
				return 0f;
			}

			double num2 = values[0];
			for (int i = 1; i < num; i++) {
				if (values[i] > num2) {
					num2 = values[i];
				}
			}

			return num2;
		}
		
		public static double Min(double a, double b) {
			return (a < b) ? a : b;
		}

		public static double Min(params double[] values) {
			int num = values.Length;
			if (num == 0) {
				return 0f;
			}

			double num2 = values[0];
			for (int i = 1; i < num; i++) {
				if (values[i] < num2) {
					num2 = values[i];
				}
			}

			return num2;
		}
	}
}
