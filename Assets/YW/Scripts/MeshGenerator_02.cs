using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProceduralToolkit.Samples
{
    /// <summary>
    /// A fully procedural chair generator, creates entire mesh from scratch and paints it's vertices
    /// </summary>
    public static class MeshGenerator_02
    {
        //ㅏ
        public static MeshDraft K(float radius, int segment, float height)
        {
            var k = new MeshDraft { name = "K" };

            k.Add(Diagonal(new Vector3(height * 0.4605f, height * 0.4923f, 0), radius, segment, height * 0.8123f, 0f));
            k.Add(Diagonal(new Vector3(height * 0.5959f, height * 0.5436f, 0), radius, segment, height * 0.2f, -90f));
            return k;
        }


        //ㅑ
        public static MeshDraft I(float radius, int segment, float height)
        {
            var i = new MeshDraft { name = "I" };
            
            i.Add(Diagonal(new Vector3(height * 0.4605f, height * 0.4923f, 0), radius, segment, height * 0.8123f, 0f));
            i.Add(Diagonal(new Vector3(height * 0.5938f, height * 0.6667f, 0), radius, segment, height * 0.2f, -90f));
            i.Add(Diagonal(new Vector3(height * 0.5938f, height * 0.4062f, 0), radius, segment, height * 0.2f, -90f));

            return i;
        }

        //ㅓ
        public static MeshDraft J(float radius, int segment, float height)
        {
            var j = new MeshDraft { name = "J" };

            j.Add(Diagonal(new Vector3(height * 0.5723f, height * 0.4923f, 0), radius, segment, height * 0.8123f, 0f));
            j.Add(Diagonal(new Vector3(height * 0.44f, height * 0.5508f, 0), radius, segment, height * 0.2133f, -90f));

            return j;
        }

        //ㅕ
        public static MeshDraft U(float radius, int segment, float height)
        {
            var u = new MeshDraft { name = "U" };

            u.Add(Diagonal(new Vector3(height * 0.5785f, height * 0.4903f, 0), radius, segment, height * 0.8123f, 0f));
            u.Add(Diagonal(new Vector3(height * 0.4431f, height * 0.6708f, 0), radius, segment, height * 0.2133f, -90f));
            u.Add(Diagonal(new Vector3(height * 0.4431f, height * 0.4082f, 0), radius, segment, height * 0.2133f, -90f));

            return u;
        }



        //ㅗ
        public static MeshDraft H(float radius, int segment, float height)
        {
            var h = new MeshDraft { name = "H" };

            h.Add(Diagonal(new Vector3(height * 0.5015f, height * 0.5333f, 0), radius, segment, height * 0.3262f, 0f));
            h.Add(Diagonal(new Vector3(height * 0.5005f, height * 0.3477f, 0), radius, segment, height * 0.7703f, -90f));

            return h;
        }


        //ㅛ
        public static MeshDraft Y(float radius, int segment, float height)
        {
            var y = new MeshDraft { name = "Y" };

            y.Add(Diagonal(new Vector3(height * 0.361f, height * 0.5282f, 0), radius, segment, height * 0.3159f, 0f));
            y.Add(Diagonal(new Vector3(height * 0.641f, height * 0.5282f, 0), radius, segment, height * 0.3159f, 0f));
            y.Add(Diagonal(new Vector3(height * 0.5005f, height * 0.3477f, 0), radius, segment, height * 0.7703f, -90f));

            return y;
        }


        //ㅜ
        public static MeshDraft N(float radius, int segment, float height)
        {
            var n = new MeshDraft { name = "N" };

            n.Add(Diagonal(new Vector3(height * 0.4985f, height * 0.3026f, 0), radius, segment, height * 0.359f, 0f));
            n.Add(Diagonal(new Vector3(height * 0.4985f, height * 0.5036f, 0), radius, segment, height * 0.7703f, -90f));

            return n;
        }


        //ㅠ
        public static MeshDraft B(float radius, int segment, float height)
        {
            var b = new MeshDraft { name = "B" };

            b.Add(Diagonal(new Vector3(height * 0.3559f, height * 0.3015f, 0), radius, segment, height * 0.359f, 0f));
            b.Add(Diagonal(new Vector3(height * 0.6482f, height * 0.3015f, 0), radius, segment, height * 0.359f, 0f));
            b.Add(Diagonal(new Vector3(height * 0.4985f, height * 0.5036f, 0), radius, segment, height * 0.7703f, -90f));

            return b;
        }


        //ㅡ
        public static MeshDraft M(float radius, int segment, float height)
        {
            var m = new MeshDraft { name = "M" };

            m.Add(Diagonal(new Vector3(height * 0.5015f, height * 0.3621f, 0), radius, segment, height * 0.7703f, -90f));

            return m;
        }


        //ㅣ
        public static MeshDraft L(float radius, int segment, float height)
        {
            var l = new MeshDraft { name = "L" };

            l.Add(Diagonal(new Vector3(height * 0.4974f, height * 0.4903f, 0), radius, segment, height * 0.8123f, 0f));

            return l;
        }


        // ㅐ
        public static MeshDraft O(float radius, int segment, float height)
        {
            var o = new MeshDraft { name = "O" };

            o.Add(Diagonal(new Vector3(height * 0.3969f, height * 0.4933f, 0), radius, segment, height * 0.7846f, 0f));
            o.Add(Diagonal(new Vector3(height * 0.6041f, height * 0.4933f, 0), radius, segment, height * 0.8123f, 0f));
            o.Add(Diagonal(new Vector3(height * 0.5015f, height * 0.5436f, 0), radius, segment, height * 0.1579f, -90f));

            return o;
        }


        
        // ㅒ
        public static MeshDraft DoubleO(float radius, int segment, float height)
        {
            var oo = new MeshDraft { name = "DoubleO" };

            oo.Add(Diagonal(new Vector3(height * 0.3969f, height * 0.4933f, 0), radius, segment, height * 0.7846f, 0f));
            oo.Add(Diagonal(new Vector3(height * 0.6041f, height * 0.4933f, 0), radius, segment, height * 0.8123f, 0f));
            oo.Add(Diagonal(new Vector3(height * 0.5005f, height * 0.6687f, 0), radius, segment, height * 0.1579f, -90f));
            oo.Add(Diagonal(new Vector3(height * 0.5005f, height * 0.4031f, 0), radius, segment, height * 0.1579f, -90f));

            return oo;
        }


        //ㅔ
        public static MeshDraft P(float radius, int segment, float height)
        {
            var p = new MeshDraft { name = "P" };

            p.Add(Diagonal(new Vector3(height * 0.3026f, height * 0.5508f, 0), radius, segment, height * 0.1887f, -90f));
            p.Add(Diagonal(new Vector3(height * 0.4195f, height * 0.4954f, 0), radius, segment, height * 0.7846f, 0f));
            p.Add(Diagonal(new Vector3(height * 0.6144f, height * 0.4954f, 0), radius, segment, height * 0.8123f, 0f));
                    
            return p;
        }

        // ㅖ
        public static MeshDraft DoubleP(float radius, int segment, float height)
        {
            var pp = new MeshDraft { name = "DoubleP" };

            pp.Add(Diagonal(new Vector3(height * 0.3026f, height * 0.4072f, 0), radius, segment, height * 0.1887f, -90f));
            pp.Add(Diagonal(new Vector3(height * 0.3026f, height * 0.6585f, 0), radius, segment, height * 0.1887f, -90f));
            pp.Add(Diagonal(new Vector3(height * 0.4195f, height * 0.4954f, 0), radius, segment, height * 0.7846f, 0f));
            pp.Add(Diagonal(new Vector3(height * 0.6144f, height * 0.4954f, 0), radius, segment, height * 0.8123f, 0f));

            return pp;
        }

        ////sm
        //public static MeshDraft Mesh(Config config, Renderer renderer, string shaderParameter)
        //{
        //    //sm 매개변수만

        //    Assert.IsTrue(config.radius > 0);
        //    Assert.IsTrue(config.height > 0);
        //    Assert.IsTrue(config.segment > 0);

        //    Vector3 zero = Vector3.zero;
        //    Vector3 rightTop = Vector3.up * config.height / 2;

        //    List<MeshDraft> meshes02 = new List<MeshDraft>();



        //    meshes02[config.index].Paint(config.color);
        //    //sm
        //    float newSlideVal = CalculateSlideVal(config.height);
        //    renderer.material.SetFloat(shaderParameter, newSlideVal);
        //    //sm

        //    return meshes02[config.index];
        //}


        private static MeshDraft Horizontal(Vector3 center, float radius, int segment, float height)
        {
            var draft = MeshDraft.Cylinder(radius, segment, height, true);

            Vector3 zeroVerti = Vector3.right * height / 2;
            draft.Rotate(Quaternion.Euler(0, 0, 90));
            draft.Move(zeroVerti);

            draft.Move(center);

            return draft;
        }

        private static MeshDraft Vertical(Vector3 center, float radius, int segment, float height)
        {
            var draft = MeshDraft.Cylinder(radius, segment, height, true);

            Vector3 zeroHorizon = Vector3.up * height / 2;
            draft.Move(zeroHorizon);

            draft.Move(center);

            return draft;
        }


        // 대각선 HJ 
        private static MeshDraft Diagonal(Vector3 center, float radius, int segment, float height, float angle)
        {
            var draft = MeshDraft.Cylinder(radius, segment, height, true);

            //Vector3 zeroVerti = Vector3.right * height / 2;
            draft.Rotate(Quaternion.Euler(0, 0, angle));
            //draft.Move(zeroVerti);

            draft.Move(center);

            return draft;
        }



        //sm
        private static float CalculateSlideVal(float height)
        {
            float maxHight = 1.2f;
            return height / maxHight;
        }
        
        private static void MaterialSetting(float height, Renderer renderer, string shaderParameter)
        {
            float newSlideVal = CalculateSlideVal(height);
            renderer.material.SetFloat(shaderParameter, newSlideVal);
        }
        //sm
    }
}
