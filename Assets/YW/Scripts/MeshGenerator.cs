using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProceduralToolkit.Samples
{
    public partial class MeshGenerator
    {

        
        // ㄱ
        public static MeshDraft Giyuk(float radius, int segment, float height)
        {
            var giyuk = new MeshDraft { name = "Giyuk" };

            //Vector3.up = (0,1,0) * height = (0,height,0)
            // new Vector3(0,height,0)
            // Vector3.up * height -> new Vector3(0,height * 오빠의숫자,0)

            giyuk.Add(Diagonal(new Vector3(height * 0.4933f, height * 0.7846f, 0), radius, segment, height * 0.7887f, -90f));
            giyuk.Add(Diagonal(new Vector3(height * 0.8482f, height * 0.4708f, 0), radius, segment, height * 0.5805f, 0f));

            //meshes[config.index].Paint(config.color);
    
            return giyuk;

        }

        //ㄲ
        public static MeshDraft DoubleGiyuk(float radius, int segment, float height)
        {
            var doubleGiyuk = new MeshDraft { name = "DoubleGiyuk" };



            doubleGiyuk.Add(Diagonal(new Vector3(height * 0.2656f, height * 0.7815f, 0), radius, segment, height * 0.4092f, -90f));
            doubleGiyuk.Add(Diagonal(new Vector3(height * 0.4308f, height * 0.4718f, 0), radius, segment, height * 0.6123f, 0f));

            doubleGiyuk.Add(Diagonal(new Vector3(height * 0.7354f, height * 0.7815f, 0), radius, segment, height * 0.3959f, -90.0f));
            doubleGiyuk.Add(Diagonal(new Vector3(height * 0.8944f, height * 0.4718f, 0), radius, segment, height * 0.6123f, -0f));


            //meshes[config.index].Paint(config.color);
            return doubleGiyuk;
        }

        // ㄴ
        public static MeshDraft Nieun(float radius, int segment, float height)
        {
            var nieun = new MeshDraft { name = "Nieun" };


            nieun.Add(Diagonal(new Vector3(height * 0.1497f, height * 0.5149f, 0), radius, segment, height * 0.681f, 0f));
            nieun.Add(Diagonal(new Vector3(height * 0.5385f, height * 0.2113f, 0), radius, segment, height * 0.7262f, -90f));

            return nieun;
        }

        // ㄷ
        public static MeshDraft Digeuk(float radius, int segment, float height)
        {
            var digeuk = new MeshDraft { name = "Digeuk" };
    

            digeuk.Add(Diagonal(new Vector3(height * 0.5354f, height * 0.8113f, 0), radius, segment, height * 0.7138f, -90f));
            digeuk.Add(Diagonal(new Vector3(height * 0.1497f, height * 0.5149f, 0), radius, segment, height * 0.6728f, 0f));
            digeuk.Add(Diagonal(new Vector3(height * 0.5385f, height * 0.2113f, 0), radius, segment, height * 0.7262f, -90f));            
            
            return digeuk;
        }



        //ㄸ
        public static MeshDraft DoubleDigeuk(float radius, int segment, float height)
        {
            var doubleDigeuk = new MeshDraft { name = "DoubleDigeuk" };


            doubleDigeuk.Add(Diagonal(new Vector3(height * 0.2697f, height * 0.7815f, 0), radius, segment, height * 0.3826f, -90f));
            doubleDigeuk.Add(Diagonal(new Vector3(height * 0.1149f, height * 0.4718f, 0), radius, segment, height * 0.6123f, 0f));
            doubleDigeuk.Add(Diagonal(new Vector3(height * 0.3005f, height * 0.2082f, 0), radius, segment, height * 0.3456f, -86.0f));
            
            doubleDigeuk.Add(Diagonal(new Vector3(height * 0.7241f, height * 0.7815f, 0), radius, segment, height * 0.3938f, -90f));
            doubleDigeuk.Add(Diagonal(new Vector3(height * 0.5631f, height * 0.4718f, 0), radius, segment, height * 0.6123f, 0f));
            doubleDigeuk.Add(Diagonal(new Vector3(height * 0.7487f, height * 0.2082f, 0), radius, segment, height * 0.3456f, -87.0f));
            

            return doubleDigeuk;
        }

        // ㄹ
        public static MeshDraft Rieul(float radius, int segment, float height)
        {
            var rieul = new MeshDraft { name = "Rieul" };

            rieul.Add(Diagonal(new Vector3(height * 0.4615f, height * 0.8133f, 0), radius, segment, height * 0.7077f, -90f));
            rieul.Add(Diagonal(new Vector3(height * 0.8379f, height * 0.6615f, 0), radius, segment, height * 0.3805f, 0f));            
            rieul.Add(Diagonal(new Vector3(height * 0.4646f, height * 0.5118f, 0), radius, segment, height * 0.7077f, -90f));
            rieul.Add(Diagonal(new Vector3(height * 0.1467f, height * 0.3262f, 0), radius, segment, height * 0.3179f, 0f));
            rieul.Add(Diagonal(new Vector3(height * 0.5344f, height * 0.2051f, 0), radius, segment, height * 0.72f, -90f));            

            return rieul;
        }


        // ㅁ
        public static MeshDraft Mieum(float radius, int segment, float height)
        {
            var mieum = new MeshDraft { name = "Mieum" };

            Vector3 rightBottom = Vector3.right * height;
            Vector3 rightTop = Vector3.up * height;

            mieum.Add(Diagonal(new Vector3(height * 0.1487f, height * 0.5528f, 0), radius, segment, height * 0.599f, 0f)); 
            mieum.Add(Diagonal(new Vector3(height * 0.5354f, height * 0.8113f, 0), radius, segment, height * 0.7026f, -90f)); 
            mieum.Add(Diagonal(new Vector3(height * 0.8503f, height * 0.4759f, 0), radius, segment, height * 0.599f, 0f)); 
            mieum.Add(Diagonal(new Vector3(height * 0.4636f, height * 0.2113f, 0), radius, segment, height * 0.7026f, -90f)); 


            return mieum;
        }

        // ㅂ
        public static MeshDraft Bieub(float radius, int segment, float height)
        {
            var bieub = new MeshDraft { name = "Bieub" };

            bieub.Add(Diagonal(new Vector3(height * 0.1497f, height * 0.5118f, 0), radius, segment, height * 0.6728f, 0f)); 
            bieub.Add(Diagonal(new Vector3(height * 0.8523f, height * 0.5118f, 0), radius, segment, height * 0.6728f, 0f)); 
            bieub.Add(Diagonal(new Vector3(height * 0.5015f, height * 0.5497f, 0), radius, segment, height * 0.6554f, -90f)); 
            bieub.Add(Diagonal(new Vector3(height * 0.5015f, height * 0.2113f, 0), radius, segment, height * 0.6554f, -90f)); 


            return bieub;
        }

        // ㅃ
        
        public static MeshDraft DoubleBieub(float radius, int segment, float height)
        {
            var doubleBieub = new MeshDraft { name = "DoubleBieub" };

            doubleBieub.Add(Diagonal(new Vector3(height * 0.1528f, height * 0.4923f, 0), radius, segment, height * 0.6585f, 0f));
            doubleBieub.Add(Diagonal(new Vector3(height * 0.5077f, height * 0.4923f, 0), radius, segment, height * 0.6585f, 0f));
            doubleBieub.Add(Diagonal(new Vector3(height * 0.8513f, height * 0.4923f, 0), radius, segment, height * 0.6585f, 0f));
            
            doubleBieub.Add(Diagonal(new Vector3(height * 0.3303f, height * 0.5508f, 0), radius, segment, height * 0.2903f, -90f));
            doubleBieub.Add(Diagonal(new Vector3(height * 0.6779f, height * 0.5508f, 0), radius, segment, height * 0.2903f, -90f));
            doubleBieub.Add(Diagonal(new Vector3(height * 0.3303f, height * 0.201f, 0), radius, segment, height * 0.2903f, -90f));
            doubleBieub.Add(Diagonal(new Vector3(height * 0.6779f, height * 0.201f, 0), radius, segment, height * 0.2903f, -90f));

            return doubleBieub;
        }

        // ㅅ
        public static MeshDraft Siot(float radius, int segment, float height)
        {
            var siot = new MeshDraft { name = "Siot" };
            //float length = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(height * 0.5f, 2));

            //siot.Add(Diagonal(new Vector3(height * 0.2358f,height * 0.5128f,0), radius, segment, height*0.7138f, -30.0f));
            //siot.Add(Diagonal(new Vector3(height * f, height * 0.5f,0), radius, segment, length, -150.0f));

            siot.Add(Diagonal(new Vector3(height * 0.2636f, height * 0.3221f, 0), radius, segment, height * 0.3692f, -51f));
            siot.Add(Diagonal(new Vector3(height * 0.4769f, height * 0.6338f, 0), radius, segment, height * 0.4677f, -23f));
            siot.Add(Diagonal(new Vector3(height * 0.6872f, height * 0.3662f, 0), radius, segment, height * 0.5785f, -311f));
        
            return siot;
        }


        // ㅆ
        public static MeshDraft DoubleSiot(float radius, int segment, float height)
        {
            var doubleSiot = new MeshDraft { name = "DoubleSiot" };

            //float length = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(height * 0.5f, 2));

            doubleSiot.Add(Diagonal(new Vector3(height * 0.2358f, height * 0.5128f, 0), radius, segment, height * 0.7138f, -22.0f));
            doubleSiot.Add(Diagonal(new Vector3(height * 0.3774f, height * 0.36f, 0), radius, segment, height*0.4338f, -318.0f));

            doubleSiot.Add(Diagonal(new Vector3(height * 0.66f, height * 0.535f, 0), radius, segment, height*0.7138f, -21.0f));
            doubleSiot.Add(Diagonal(new Vector3(height * 0.8f, height * 0.36f, 0), radius, segment, height*0.4215f, -325.0f));

            return doubleSiot;
        }

        // ㅇ
        public static MeshDraft Ieung(float radius, int segment, float height)
        {
            var ieung = new MeshDraft { name = "Ieung" };
            float length = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(height * 0.5f, 2));

            // 도넛 스크립트로 대체.
            //return ieung;

            ieung.Add(Diagonal(new Vector3(height * 0.1179f, height * 0.5036f, 0), radius, segment, height * 0.2933f, -0f));
            ieung.Add(Diagonal(new Vector3(height * 0.1528f, height * 0.7036f, 0), radius, segment, height*0.1405f, -30f));
            ieung.Add(Diagonal(new Vector3(height * 0.2338f, height * 0.7774f, 0), radius, segment, height * 0.1405f, -60f));
            ieung.Add(Diagonal(new Vector3(height * 0.4954f, height * 0.8103f, 0), radius, segment, height*0.4318f, -90f));
            
            ieung.Add(Diagonal(new Vector3(height * 0.7569f, height * 0.7774f, 0), radius, segment, height * 0.1405f, -120f));
            ieung.Add(Diagonal(new Vector3(height * 0.8379f, height * 0.7036f, 0), radius, segment, height*0.1405f, -150f));
            ieung.Add(Diagonal(new Vector3(height * 0.8728f, height * 0.5036f, 0), radius, segment, height * 0.2933f, -0f));
            ieung.Add(Diagonal(new Vector3(height * 0.1528f, height * 0.3036f, 0), radius, segment, height*0.1405f, -150f));

            ieung.Add(Diagonal(new Vector3(height * 0.2338f, height * 0.2297f, 0), radius, segment, height * 0.1405f, -120f));
            ieung.Add(Diagonal(new Vector3(height * 0.7569f, height * 0.2297f, 0), radius, segment, height*0.1405f, -240f));
            ieung.Add(Diagonal(new Vector3(height * 0.8379f, height * 0.3036f, 0), radius, segment, height * 0.1405f, -210f));
            ieung.Add(Diagonal(new Vector3(height * 0.4954f, height * 0.1969f, 0), radius, segment, height*0.4318f, -90f));
            
            return ieung;

        }






        // ㅈ
        public static MeshDraft Jiet(float radius, int segment, float height)
        {
            var jiet = new MeshDraft { name = "Jiet" };

            float length = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(height * 0.5f, 2));

            //float diagonal = Mathf.Sqrt(Mathf.Pow(height, 2));
            //jiet.Add(Diagonal(new Vector3(-height * 0.1f, height / 2, 0) + Vector3.right * height / 2,
            //                           radius, segment, height + height * 0.1f, -45.0f));
            //jiet.Add(Diagonal(new Vector3(diagonal * 0.4f, diagonal * 0.3f, 0) + Vector3.right * height / 2,
            //                            radius, segment, diagonal * 0.6f, 45.0f));

            jiet.Add(Diagonal(new Vector3(height * 0.2544f, height * 0.3846f, 0), radius, segment, height*0.4031f, -55f));
            jiet.Add(Diagonal(new Vector3(height * 0.4620f, height * 0.6351f, 0), radius, segment, height*0.3518f, -23.0f));
            jiet.Add(Diagonal(new Vector3(height * 0.4903f, height * 0.7856f, 0), radius, segment, height*0.7631f, -90.0f));
            jiet.Add(Diagonal(new Vector3(height * 0.6944f, height * 0.3774f, 0), radius, segment, height*0.559f, -305.0f));

            return jiet;
        }


        // ㅉ
        public static MeshDraft DoubleJiet(float radius, int segment, float height)
        {
            var doublejiet = new MeshDraft { name = "DoubleJiet" };

            float length = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(height * 0.5f, 2));

            
            doublejiet.Add(Diagonal(new Vector3(height * 0.2656f, height * 0.7815f, 0), radius, segment, height * 0.4092f, -90f));
            doublejiet.Add(Diagonal(new Vector3(height * 0.7323f, height * 0.7815f, 0), radius, segment, height * 0.3959f, -90f));

            doublejiet.Add(Diagonal(new Vector3(height * 0.2154f, height * 0.4687f, 0), radius, segment, height * 0.6256f, -22.0f));
            doublejiet.Add(Diagonal(new Vector3(height * 0.3795f, height * 0.3559f, 0), radius, segment, height * 0.4338f, -318.0f));

            doublejiet.Add(Diagonal(new Vector3(height * 0.6369f, height * 0.481f, 0), radius, segment, height * 0.6185f, -21.0f));
            doublejiet.Add(Diagonal(new Vector3(height * 0.7969f, height * 0.3497f, 0), radius, segment, height * 0.4215f, -325.0f));

            return doublejiet;
        }


        // ㅊ
        public static MeshDraft Chiet(float radius, int segment, float height)
        {
            var chiet = new MeshDraft { name = "Chiet" };

            float length = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(height * 0.5f, 2));
            //float diagonal = Mathf.Sqrt(Mathf.Pow(height, 2));
            //chiet.Add(Diagonal(new Vector3(-height * 0.1f, height / 2, 0)+ Vector3.right * height / 2,
            //                            radius, segment, height + height * 0.1f, -45.0f));
            //chiet.Add(Diagonal(new Vector3(diagonal * 0.4f, diagonal * 0.3f, 0)+ Vector3.right * height / 2,
            //                            radius, segment, diagonal * 0.6f, 45.0f));

            chiet.Add(Diagonal(new Vector3(height * 0.5097f, height * 0.8738f, 0), radius, segment, height*0.2297f, 0f));
            chiet.Add(Diagonal(new Vector3(height * 0.4892f, height * 0.7354f, 0), radius, segment, height*0.7631f, -90f));
            chiet.Add(Diagonal(new Vector3(height * 0.4656f, height * 0.5836f, 0), radius, segment, height*0.3036f, -23f));
            chiet.Add(Diagonal(new Vector3(height * 0.2564f, height * 0.3405f, 0), radius, segment, height*0.4031f, -55f));
            chiet.Add(Diagonal(new Vector3(height * 0.6974f, height * 0.3805f, 0), radius, segment, height*0.559f, -305.0f));


            return chiet;
        }


        // ㅋ
        public static MeshDraft Kieuk(float radius, int segment, float height)
        {
            var kieuk = new MeshDraft { name = "Kieuk" };


            kieuk.Add(Diagonal(new Vector3(height * 0.4933f, height * 0.7856f, 0), radius, segment, height*0.7887f, -90f));
            kieuk.Add(Diagonal(new Vector3(height * 0.4636f, height * 0.4636f, 0), radius, segment, height*0.7241f, -267f));
            kieuk.Add(Diagonal(new Vector3(height * 0.8492f, height * 0.4697f, 0), radius, segment, height*0.5805f, 0f));

            return kieuk;
        }

        // ㅌ
        public static MeshDraft Tigeuk(float radius, int segment, float height)
        {
            var tigeuk = new MeshDraft { name = "Tigeuk" };

            tigeuk.Add(Diagonal(new Vector3(height * 0.4933f, height * 0.8031f, 0), radius, segment, height*0.7651f, -90f));
            tigeuk.Add(Diagonal(new Vector3(height * 0.5056f, height * 0.2195f, 0), radius, segment, height*0.7877f, -90f));
            tigeuk.Add(Diagonal(new Vector3(height * 0.5272f, height * 0.5169f, 0), radius, segment, height*0.6985f, -90f));
            tigeuk.Add(Diagonal(new Vector3(height * 0.1477f, height * 0.5097f, 0), radius, segment, height*0.5344f, 0f));

            return tigeuk;
        }

        // ㅍ
        public static MeshDraft Pieup(float radius, int segment, float height)
        {
            var pieup = new MeshDraft { name = "Pieup" };

            pieup.Add(Diagonal(new Vector3(height * 0.5056f, height * 0.7887f, 0), radius, segment, height*0.8195f, -90f));
            pieup.Add(Diagonal(new Vector3(height * 0.5026f, height * 0.2215f, 0), radius, segment, height*0.8338f, -90f));
            pieup.Add(Diagonal(new Vector3(height * 0.3364f, height * 0.5067f, 0), radius, segment, height*0.5179f, 0f));
            pieup.Add(Diagonal(new Vector3(height * 0.6677f, height * 0.5067f, 0), radius, segment, height*0.5179f, 0f));

            return pieup;
        }

        // ㅎ
        public static MeshDraft Hieu(float radius, int segment, float height)
        {
            var hieu = new MeshDraft { name = "Hieu" };
            float length = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(height * 0.5f, 2));

            hieu.Add(Diagonal(new Vector3(height * 0.1179f, height * 0.3518f, 0), radius, segment, height * 0.0985f, -0f));
            hieu.Add(Diagonal(new Vector3(height * 0.1528f, height * 0.4503f, 0), radius, segment, height*0.1405f, -30f));
            hieu.Add(Diagonal(new Vector3(height * 0.2338f, height * 0.5251f, 0), radius, segment, height * 0.1405f, -60f));
            hieu.Add(Diagonal(new Vector3(height * 0.4954f, height * 0.5621f, 0), radius, segment, height*0.4318f, -90f));
            
            hieu.Add(Diagonal(new Vector3(height * 0.7569f, height * 0.5251f, 0), radius, segment, height * 0.1405f, -120f));
            hieu.Add(Diagonal(new Vector3(height * 0.8379f, height * 0.4503f, 0), radius, segment, height*0.1405f, -150f));
            hieu.Add(Diagonal(new Vector3(height * 0.8728f, height * 0.3518f, 0), radius, segment, height * 0.0985f, -0f));
            hieu.Add(Diagonal(new Vector3(height * 0.8379f, height * 0.2718f, 0), radius, segment, height*0.1405f, -210f));

            hieu.Add(Diagonal(new Vector3(height * 0.7569f, height * 0.1785f, 0), radius, segment, height * 0.1405f, -240f));
            hieu.Add(Diagonal(new Vector3(height * 0.4954f, height * 0.1528f, 0), radius, segment, height*0.4318f, -270f));
            hieu.Add(Diagonal(new Vector3(height * 0.2338f, height * 0.1785f, 0), radius, segment, height * 0.1405f, -300f));
            hieu.Add(Diagonal(new Vector3(height * 0.1528f, height * 0.2718f, 0), radius, segment, height*0.1405f, -330f));
            
            hieu.Add(Diagonal(new Vector3(height * 0.4954f, height * 0.7549f, 0), radius, segment, height * 0.8379f, -90f));
            hieu.Add(Diagonal(new Vector3(height * 0.4954f, height * 0.8882f, 0), radius, segment, height*0.2246f, -0f));

            return hieu;
        }



        // 가로
        private static MeshDraft Horizontal(Vector3 center, float radius, int segment, float height)
        {
            var draft = MeshDraft.Cylinder(radius, segment, height, true);

            Vector3 zeroVerti = Vector3.right * height / 2;
            draft.Rotate(Quaternion.Euler(0, 0, 90));
            draft.Move(zeroVerti);

            draft.Move(center);

            return draft;
        }

        // 세로
        private static MeshDraft Vertical(Vector3 center, float radius, int segment, float height)
        {
            var draft = MeshDraft.Cylinder(radius, segment, height, true);

            Vector3 zeroHorizon = Vector3.up * height / 2;
            draft.Move(zeroHorizon);

            draft.Move(center);

            return draft;
        }

        // 대각선
        private static MeshDraft Diagonal(Vector3 center, float radius, int segment, float height, float angle)
        {
            var draft = MeshDraft.Cylinder(radius, segment, height, true);

            //Vector3 zeroVerti = Vector3.right * height / 2;
            draft.Rotate(Quaternion.Euler(0, 0, angle));
            //draft.Move(zeroVerti);

            draft.Move(center);

            return draft;
        }


        // private static BoxCollider AddBoxColliderForCylinder(GameObject parent, Vector3 center, float radius, float height, float angle)
        // {
        //     GameObject colliderObj = new GameObject("CylinderCollider");
        //     colliderObj.transform.SetParent(parent.transform);
        //     colliderObj.transform.localPosition = center;
        //     colliderObj.transform.localRotation = Quaternion.Euler(0, 0, angle);

        //     BoxCollider boxCollider = colliderObj.AddComponent<BoxCollider>();

        //     if (angle == 0f || angle == 180f)
        //     {
        //         boxCollider.size = new Vector3(radius * 2, height, radius * 2);
        //         boxCollider.center = new Vector3(0, height / 2, 0);
        //     }
        //     else if (angle == 90f || angle == -90f)
        //     {
        //         boxCollider.size = new Vector3(height, radius * 2, radius * 2);
        //         boxCollider.center = new Vector3(-height / 2, 0, 0);
        //     }

        //     return boxCollider;
        // }

        // // 복합 객체에 Rigidbody 추가
        // public GameObject CreateMeshWithPhysics(MeshDraft draft)
        // {
        //     GameObject meshObject = new GameObject(draft.name);
        //     MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
        //     meshFilter.mesh = draft.ToMesh(); // Assuming MeshDraft has a method to convert it to a Mesh.

        //     meshObject.AddComponent<MeshRenderer>();

        //     // For each cylinder in the draft, add a collider
        //     // (NOTE: This assumes that your draft is made up of a series of cylinders.)
        //     foreach (Vector3 vertex in draft.vertices)
        //     {
        //         AddBoxColliderForCylinder(meshObject, vertex, radius, height, 0); // Update with correct angle if needed.
        //     }

        //     Rigidbody rb = meshObject.AddComponent<Rigidbody>();
        //     rb.useGravity = true;

        //     return meshObject;
        // }

        // public static GameObject AddColliderToDraft(MeshDraft draft, GameObject parent)
        // {
        //     GameObject colliderObj = new GameObject("Collider");
        //     colliderObj.transform.position = draft.GetCentroid();  // Assuming GetCentroid() gets the central position of the MeshDraft
        //     BoxCollider collider = colliderObj.AddComponent<BoxCollider>();
        //     collider.size = draft.GetBounds().size;  // Assuming GetBounds() gets the bounding box of the MeshDraft
        //     colliderObj.transform.SetParent(parent.transform);
        //     return colliderObj;
        // }


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



    }
}
