Shader "Custom/Shader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}

		_R("R",Range(-0.5,1)) = 0
		_Width("Width",Range(0,0.5)) = 0

		[Toggle]_Show("Show",Range(0,1)) = 0

		_OriginPos("Origin",Vector) = (0,0,0,0)

	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"


			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			half4 _MainTex_TexelSize;
			float _R;
			float _Width;
			bool _Show;
			float4 _OriginPos;

			fixed4 frag(v2f i) : SV_Target
			{
				//中心偏移
				float2 uv = i.uv - _OriginPos;
				uv.x *= _MainTex_TexelSize.y / _MainTex_TexelSize.x;

				//半径位置
				float2 center = float2(1,1)*_R;

				float dis = sqrt(pow(uv.x, 2) + pow(uv.y, 2));

				//半个宽度
				float halfWid = _Width / 2;
				float centerR = _R + halfWid;

				fixed4 col = float4(0,0,0,0);

				//强度
				float power = 1;
				if (dis > _R&&dis < _R + _Width) {
					power = 1 - abs(dis - centerR) / halfWid;
					col.r = power;
				}

				//是否显示红黑图
				if (_Show == false) {
						if (dis > _R&&dis < _R + _Width) {
							power *= 10;
							col = tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x* power, _MainTex_TexelSize.y*power));
						}
						else {
							col = tex2D(_MainTex, i.uv);
						}
					}
				return col;
			}
			ENDCG
		}
		}
}
————————————————
版权声明：本文为CSDN博主「血月笙歌」的原创文章，遵循 CC 4.0 BY - SA 版权协议，转载请附上原文出处链接及本声明。
原文链接：https ://blog.csdn.net/jueane/article/details/78663199