
#include "Tests.h"

using namespace std;

void Matrix_TrsConstructorNoTransforms_CreatesIdentity()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 0, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(1.0, m.Get(0, 0));
    AssertEqual(0.0, m.Get(0, 1));
    AssertEqual(0.0, m.Get(0, 2));
    AssertEqual(0.0, m.Get(0, 3));
    AssertEqual(0.0, m.Get(1, 0));
    AssertEqual(1.0, m.Get(1, 1));
    AssertEqual(0.0, m.Get(1, 2));
    AssertEqual(0.0, m.Get(1, 3));
    AssertEqual(0.0, m.Get(2, 0));
    AssertEqual(0.0, m.Get(2, 1));
    AssertEqual(1.0, m.Get(2, 2));
    AssertEqual(0.0, m.Get(2, 3));
    AssertEqual(0.0, m.Get(3, 0));
    AssertEqual(0.0, m.Get(3, 1));
    AssertEqual(0.0, m.Get(3, 2));
    AssertEqual(1.0, m.Get(3, 3));
}

void Matrix_TrsConstructorTranslation_CreatesWithTranslation()
{
    // when:
    FbxVector4 t = FbxVector4(2, 3, 4);
    FbxVector4 r = FbxVector4(0, 0, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(1.0, m.Get(0, 0), 0.00001);
    AssertEqual(0.0, m.Get(0, 1), 0.00001);
    AssertEqual(0.0, m.Get(0, 2), 0.00001);
    AssertEqual(0.0, m.Get(0, 3), 0.00001);
    AssertEqual(0.0, m.Get(1, 0), 0.00001);
    AssertEqual(1.0, m.Get(1, 1), 0.00001);
    AssertEqual(0.0, m.Get(1, 2), 0.00001);
    AssertEqual(0.0, m.Get(1, 3), 0.00001);
    AssertEqual(0.0, m.Get(2, 0), 0.00001);
    AssertEqual(0.0, m.Get(2, 1), 0.00001);
    AssertEqual(1.0, m.Get(2, 2), 0.00001);
    AssertEqual(0.0, m.Get(2, 3), 0.00001);
    AssertEqual(2.0, m.Get(3, 0), 0.00001);
    AssertEqual(3.0, m.Get(3, 1), 0.00001);
    AssertEqual(4.0, m.Get(3, 2), 0.00001);
    AssertEqual(1.0, m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorRotationX_CreatesWithRotationX()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(22.5, 0, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(1.0,       m.Get(0, 0), 0.00001);
    AssertEqual(0.0,       m.Get(0, 1), 0.00001);
    AssertEqual(0.0,       m.Get(0, 2), 0.00001);
    AssertEqual(0.0,       m.Get(0, 3), 0.00001);
    AssertEqual(0.0,       m.Get(1, 0), 0.00001);
    AssertEqual(0.92388,   m.Get(1, 1), 0.00001);
    AssertEqual(0.382683,  m.Get(1, 2), 0.00001);
    AssertEqual(0.0,       m.Get(1, 3), 0.00001);
    AssertEqual(0.0,       m.Get(2, 0), 0.00001);
    AssertEqual(-0.382683, m.Get(2, 1), 0.00001);
    AssertEqual(0.92388,   m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(0.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorRotationY_CreatesWithRotationY()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 35, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(0.819152,  m.Get(0, 0), 0.00001);
    AssertEqual(0.0,       m.Get(0, 1), 0.00001);
    AssertEqual(-0.573576, m.Get(0, 2), 0.00001);
    AssertEqual(0.0,       m.Get(0, 3), 0.00001);
    AssertEqual(0.0,       m.Get(1, 0), 0.00001);
    AssertEqual(1.0,       m.Get(1, 1), 0.00001);
    AssertEqual(0.0,       m.Get(1, 2), 0.00001);
    AssertEqual(0.0,       m.Get(1, 3), 0.00001);
    AssertEqual(0.573576,  m.Get(2, 0), 0.00001);
    AssertEqual(0.0,       m.Get(2, 1), 0.00001);
    AssertEqual(0.819152,  m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(0.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorRotationZ_CreatesWithRotationZ()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 0, 55);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(0.573576,  m.Get(0, 0), 0.00001);
    AssertEqual(0.819152,  m.Get(0, 1), 0.00001);
    AssertEqual(0.0,       m.Get(0, 2), 0.00001);
    AssertEqual(0.0,       m.Get(0, 3), 0.00001);
    AssertEqual(-0.819152, m.Get(1, 0), 0.00001);
    AssertEqual(0.573576,  m.Get(1, 1), 0.00001);
    AssertEqual(0.0,       m.Get(1, 2), 0.00001);
    AssertEqual(0.0,       m.Get(1, 3), 0.00001);
    AssertEqual(0.0,       m.Get(2, 0), 0.00001);
    AssertEqual(0.0,       m.Get(2, 1), 0.00001);
    AssertEqual(1.0,       m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(0.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorRotationXY_CreatesWithRotationXY()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(22.5, 35, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(0.819152,  m.Get(0, 0), 0.00001);
    AssertEqual(0.0,       m.Get(0, 1), 0.00001);
    AssertEqual(-0.573576, m.Get(0, 2), 0.00001);
    AssertEqual(0.0,       m.Get(0, 3), 0.00001);
    AssertEqual(0.219498,  m.Get(1, 0), 0.00001);
    AssertEqual(0.92388,   m.Get(1, 1), 0.00001);
    AssertEqual(0.313476,  m.Get(1, 2), 0.00001);
    AssertEqual(0.0,       m.Get(1, 3), 0.00001);
    AssertEqual(0.529916,  m.Get(2, 0), 0.00001);
    AssertEqual(-0.382683, m.Get(2, 1), 0.00001);
    AssertEqual(0.756798,  m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(0.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorRotationYZ_CreatesWithRotationYZ()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 35, 55);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(0.469846,  m.Get(0, 0), 0.00001);
    AssertEqual(0.67101,   m.Get(0, 1), 0.00001);
    AssertEqual(-0.573576, m.Get(0, 2), 0.00001);
    AssertEqual(0.0,       m.Get(0, 3), 0.00001);
    AssertEqual(-0.819152, m.Get(1, 0), 0.00001);
    AssertEqual(0.573576,  m.Get(1, 1), 0.00001);
    AssertEqual(0.0,       m.Get(1, 2), 0.00001);
    AssertEqual(0.0,       m.Get(1, 3), 0.00001);
    AssertEqual(0.32899,   m.Get(2, 0), 0.00001);
    AssertEqual(0.469846,  m.Get(2, 1), 0.00001);
    AssertEqual(0.819152,  m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(0.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorRotationXZ_CreatesWithRotationXZ()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(22.5, 0, 55);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(0.573576,  m.Get(0, 0), 0.00001);
    AssertEqual(0.819152,  m.Get(0, 1), 0.00001);
    AssertEqual(0.0,       m.Get(0, 2), 0.00001);
    AssertEqual(0.0,       m.Get(0, 3), 0.00001);
    AssertEqual(-0.756798, m.Get(1, 0), 0.00001);
    AssertEqual(0.529916,  m.Get(1, 1), 0.00001);
    AssertEqual(0.382683,  m.Get(1, 2), 0.00001);
    AssertEqual(0.0,       m.Get(1, 3), 0.00001);
    AssertEqual(0.313476,  m.Get(2, 0), 0.00001);
    AssertEqual(-0.219498, m.Get(2, 1), 0.00001);
    AssertEqual(0.92388,   m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(0.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorRotationXYZ_CreatesWithRotationXYZ()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(22.5, 35, 55);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(0.469846,  m.Get(0, 0), 0.00001);
    AssertEqual(0.67101,   m.Get(0, 1), 0.00001);
    AssertEqual(-0.573576, m.Get(0, 2), 0.00001);
    AssertEqual(0,         m.Get(0, 3), 0.00001);
    AssertEqual(-0.630899, m.Get(1, 0), 0.00001);
    AssertEqual(0.709718,  m.Get(1, 1), 0.00001);
    AssertEqual(0.313476,  m.Get(1, 2), 0.00001);
    AssertEqual(0,         m.Get(1, 3), 0.00001);
    AssertEqual(0.617423,  m.Get(2, 0), 0.00001);
    AssertEqual(0.214583,  m.Get(2, 1), 0.00001);
    AssertEqual(0.756798,  m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(0.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorScale_CreatesWithScale()
{
    // when:
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 0, 0);
    FbxVector4 s = FbxVector4(2, 3, 4);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(2.0, m.Get(0, 0), 0.00001);
    AssertEqual(0.0, m.Get(0, 1), 0.00001);
    AssertEqual(0.0, m.Get(0, 2), 0.00001);
    AssertEqual(0.0, m.Get(0, 3), 0.00001);
    AssertEqual(0.0, m.Get(1, 0), 0.00001);
    AssertEqual(3.0, m.Get(1, 1), 0.00001);
    AssertEqual(0.0, m.Get(1, 2), 0.00001);
    AssertEqual(0.0, m.Get(1, 3), 0.00001);
    AssertEqual(0.0, m.Get(2, 0), 0.00001);
    AssertEqual(0.0, m.Get(2, 1), 0.00001);
    AssertEqual(4.0, m.Get(2, 2), 0.00001);
    AssertEqual(0.0, m.Get(2, 3), 0.00001);
    AssertEqual(0.0, m.Get(3, 0), 0.00001);
    AssertEqual(0.0, m.Get(3, 1), 0.00001);
    AssertEqual(0.0, m.Get(3, 2), 0.00001);
    AssertEqual(1.0, m.Get(3, 3), 0.00001);
}

void Matrix_TrsConstructorEverything_CreatesMatrix()
{
    // when:
    FbxVector4 t = FbxVector4(1, 0, 0);
    FbxVector4 r = FbxVector4(22.5, 45, 135);
    FbxVector4 s = FbxVector4(1, 2, 3);
    FbxMatrix m = FbxMatrix(t, r, s);

    // then:
    AssertEqual(-0.5,      m.Get(0, 0), 0.00001);
    AssertEqual(0.5,       m.Get(0, 1), 0.00001);
    AssertEqual(-0.707107, m.Get(0, 2), 0.00001);
    AssertEqual(0.0,       m.Get(0, 3), 0.00001);
    AssertEqual(-1.68925,  m.Get(1, 0), 0.00001);
    AssertEqual(-0.92388,  m.Get(1, 1), 0.00001);
    AssertEqual(0.541196,  m.Get(1, 2), 0.00001);
    AssertEqual(0.0,       m.Get(1, 3), 0.00001);
    AssertEqual(-0.574025, m.Get(2, 0), 0.00001);
    AssertEqual(2.19761,   m.Get(2, 1), 0.00001);
    AssertEqual(1.95984,   m.Get(2, 2), 0.00001);
    AssertEqual(0.0,       m.Get(2, 3), 0.00001);
    AssertEqual(1.0,       m.Get(3, 0), 0.00001);
    AssertEqual(0.0,       m.Get(3, 1), 0.00001);
    AssertEqual(0.0,       m.Get(3, 2), 0.00001);
    AssertEqual(1.0,       m.Get(3, 3), 0.00001);
}

void Matrix_Multiply()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
    FbxMatrix b = FbxMatrix(0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(1.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(1.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(1.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(2.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(3.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(4.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);

    // when:
    m = b * a;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(1.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(1.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(1.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(3.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(4.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(2.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);
}

void Matrix_Multiply_2()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(1, 0, -0, 0, 0, 0.707107, 0.707107, 0, 0, -0.707107, 0.707107, 0, 0, 0, 0, 1); // 45 degrees around x;
    FbxMatrix b = FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(1.000000f, m.Get(0, 0), 0.000001f);
    AssertEqual(0.000000f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.000000f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.000000f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.000000f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.707107f, m.Get(1, 1), 0.000001f);
    AssertEqual(0.707107f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.000000f, m.Get(1, 3), 0.000001f);
    AssertEqual(0.000000f, m.Get(2, 0), 0.000001f);
    AssertEqual(-.707107f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.707107f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.000000f, m.Get(2, 3), 0.000001f);
    AssertEqual(2.000000f, m.Get(3, 0), 0.000001f);
    AssertEqual(-.707107f, m.Get(3, 1), 0.000001f);
    AssertEqual(4.949748f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.000000f, m.Get(3, 3), 0.000001f);

    // when:
    m = b * a;

    // then:
    AssertEqual(1.000000f, m.Get(0, 0), 0.000001f);
    AssertEqual(0.000000f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.000000f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.000000f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.000000f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.707107f, m.Get(1, 1), 0.000001f);
    AssertEqual(0.707107f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.000000f, m.Get(1, 3), 0.000001f);
    AssertEqual(0.000000f, m.Get(2, 0), 0.000001f);
    AssertEqual(-.707107f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.707107f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.000000f, m.Get(2, 3), 0.000001f);
    AssertEqual(2.000000f, m.Get(3, 0), 0.000001f);
    AssertEqual(3.000000f, m.Get(3, 1), 0.000001f);
    AssertEqual(4.000000f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.000000f, m.Get(3, 3), 0.000001f);
}

void Matrix_Multiply_3()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix r = FbxMatrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
    FbxMatrix t = FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
    FbxMatrix s = FbxMatrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

    // when:
    FbxMatrix m = r * t * s;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(5.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(6.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(7.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(4.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(2.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(3.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);

    // when:
    m = r * s * t;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(5.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(6.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(7.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(28.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(10.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(18.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);

    // when:
    m = t * r * s;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(5.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(6.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(7.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(2.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(3.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(4.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);

    // when:
    m = t * s * r;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(6.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(7.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(5.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(2.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(3.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(4.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);

    // when:
    m = s * t * r;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(6.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(7.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(5.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(10.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(18.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(28.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);

    // when:
    m = s * r * t;

    // then:
    AssertEqual(0.0f, m.Get(0, 0), 0.000001f);
    AssertEqual(6.0f, m.Get(0, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(0, 3), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 1), 0.000001f);
    AssertEqual(7.0f, m.Get(1, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(1, 3), 0.000001f);
    AssertEqual(5.0f, m.Get(2, 0), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 1), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 2), 0.000001f);
    AssertEqual(0.0f, m.Get(2, 3), 0.000001f);
    AssertEqual(20.0f, m.Get(3, 0), 0.000001f);
    AssertEqual(12.0f, m.Get(3, 1), 0.000001f);
    AssertEqual(21.0f, m.Get(3, 2), 0.000001f);
    AssertEqual(1.0f, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplicationIsAssociative()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix r = FbxMatrix(0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1); // 120 degrees around axis (1,1,1);
    FbxMatrix t = FbxMatrix(1, 0, -0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 2, 3, 4, 1);
    FbxMatrix s = FbxMatrix(5, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1);

    // when:
    FbxMatrix m1 = (r * t) * s;
    FbxMatrix m2 = r * (t * s);

    // then:
    AssertEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
    AssertEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
    AssertEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
    AssertEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
    AssertEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
    AssertEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
    AssertEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
    AssertEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
    AssertEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
    AssertEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
    AssertEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
    AssertEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
    AssertEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
    AssertEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
    AssertEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
    AssertEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

    // when:
    m1 = (r * s) * t;
    m2 = r * (s * t);

    // then:
    AssertEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
    AssertEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
    AssertEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
    AssertEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
    AssertEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
    AssertEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
    AssertEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
    AssertEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
    AssertEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
    AssertEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
    AssertEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
    AssertEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
    AssertEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
    AssertEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
    AssertEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
    AssertEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

    // when:
    m1 = (s * r) * t;
    m2 = s * (r * t);

    // then:
    AssertEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
    AssertEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
    AssertEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
    AssertEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
    AssertEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
    AssertEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
    AssertEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
    AssertEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
    AssertEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
    AssertEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
    AssertEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
    AssertEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
    AssertEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
    AssertEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
    AssertEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
    AssertEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

    // when:
    m1 = (s * t) * r;
    m2 = s * (t * r);

    // then:
    AssertEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
    AssertEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
    AssertEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
    AssertEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
    AssertEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
    AssertEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
    AssertEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
    AssertEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
    AssertEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
    AssertEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
    AssertEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
    AssertEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
    AssertEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
    AssertEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
    AssertEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
    AssertEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

    // when:
    m1 = (t * s) * r;
    m2 = t * (s * r);

    // then:
    AssertEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
    AssertEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
    AssertEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
    AssertEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
    AssertEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
    AssertEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
    AssertEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
    AssertEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
    AssertEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
    AssertEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
    AssertEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
    AssertEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
    AssertEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
    AssertEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
    AssertEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
    AssertEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);

    // when:
    m1 = (t * r) * s;
    m2 = t * (r * s);

    // then:
    AssertEqual(m1.Get(0, 0), m2.Get(0, 0), 0.000001f);
    AssertEqual(m1.Get(0, 1), m2.Get(0, 1), 0.000001f);
    AssertEqual(m1.Get(0, 2), m2.Get(0, 2), 0.000001f);
    AssertEqual(m1.Get(0, 3), m2.Get(0, 3), 0.000001f);
    AssertEqual(m1.Get(1, 0), m2.Get(1, 0), 0.000001f);
    AssertEqual(m1.Get(1, 1), m2.Get(1, 1), 0.000001f);
    AssertEqual(m1.Get(1, 2), m2.Get(1, 2), 0.000001f);
    AssertEqual(m1.Get(1, 3), m2.Get(1, 3), 0.000001f);
    AssertEqual(m1.Get(2, 0), m2.Get(2, 0), 0.000001f);
    AssertEqual(m1.Get(2, 1), m2.Get(2, 1), 0.000001f);
    AssertEqual(m1.Get(2, 2), m2.Get(2, 2), 0.000001f);
    AssertEqual(m1.Get(2, 3), m2.Get(2, 3), 0.000001f);
    AssertEqual(m1.Get(3, 0), m2.Get(3, 0), 0.000001f);
    AssertEqual(m1.Get(3, 1), m2.Get(3, 1), 0.000001f);
    AssertEqual(m1.Get(3, 2), m2.Get(3, 2), 0.000001f);
    AssertEqual(m1.Get(3, 3), m2.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_00()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(118, m.Get(0, 0), 0.000001f);
    AssertEqual(177, m.Get(0, 1), 0.000001f);
    AssertEqual(295, m.Get(0, 2), 0.000001f);
    AssertEqual(413, m.Get(0, 3), 0.000001f);
    AssertEqual(0,   m.Get(1, 0), 0.000001f);
    AssertEqual(0,   m.Get(1, 1), 0.000001f);
    AssertEqual(0,   m.Get(1, 2), 0.000001f);
    AssertEqual(0,   m.Get(1, 3), 0.000001f);
    AssertEqual(0,   m.Get(2, 0), 0.000001f);
    AssertEqual(0,   m.Get(2, 1), 0.000001f);
    AssertEqual(0,   m.Get(2, 2), 0.000001f);
    AssertEqual(0,   m.Get(2, 3), 0.000001f);
    AssertEqual(0,   m.Get(3, 0), 0.000001f);
    AssertEqual(0,   m.Get(3, 1), 0.000001f);
    AssertEqual(0,   m.Get(3, 2), 0.000001f);
    AssertEqual(0,   m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_01()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(649,  m.Get(0, 0), 0.000001f);
    AssertEqual(767,  m.Get(0, 1), 0.000001f);
    AssertEqual(1003, m.Get(0, 2), 0.000001f);
    AssertEqual(1121, m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_02()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(1357, m.Get(0, 0), 0.000001f);
    AssertEqual(1711, m.Get(0, 1), 0.000001f);
    AssertEqual(1829, m.Get(0, 2), 0.000001f);
    AssertEqual(2183, m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_03()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(2419, m.Get(0, 0), 0.000001f);
    AssertEqual(2537, m.Get(0, 1), 0.000001f);
    AssertEqual(2773, m.Get(0, 2), 0.000001f);
    AssertEqual(3127, m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_04()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,   m.Get(0, 0), 0.000001f);
    AssertEqual(0,   m.Get(0, 1), 0.000001f);
    AssertEqual(0,   m.Get(0, 2), 0.000001f);
    AssertEqual(0,   m.Get(0, 3), 0.000001f);
    AssertEqual(118, m.Get(1, 0), 0.000001f);
    AssertEqual(177, m.Get(1, 1), 0.000001f);
    AssertEqual(295, m.Get(1, 2), 0.000001f);
    AssertEqual(413, m.Get(1, 3), 0.000001f);
    AssertEqual(0,   m.Get(2, 0), 0.000001f);
    AssertEqual(0,   m.Get(2, 1), 0.000001f);
    AssertEqual(0,   m.Get(2, 2), 0.000001f);
    AssertEqual(0,   m.Get(2, 3), 0.000001f);
    AssertEqual(0,   m.Get(3, 0), 0.000001f);
    AssertEqual(0,   m.Get(3, 1), 0.000001f);
    AssertEqual(0,   m.Get(3, 2), 0.000001f);
    AssertEqual(0,   m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_05()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(649,  m.Get(1, 0), 0.000001f);
    AssertEqual(767,  m.Get(1, 1), 0.000001f);
    AssertEqual(1003, m.Get(1, 2), 0.000001f);
    AssertEqual(1121, m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_06()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(1357, m.Get(1, 0), 0.000001f);
    AssertEqual(1711, m.Get(1, 1), 0.000001f);
    AssertEqual(1829, m.Get(1, 2), 0.000001f);
    AssertEqual(2183, m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_07()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(2419, m.Get(1, 0), 0.000001f);
    AssertEqual(2537, m.Get(1, 1), 0.000001f);
    AssertEqual(2773, m.Get(1, 2), 0.000001f);
    AssertEqual(3127, m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_08()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,   m.Get(0, 0), 0.000001f);
    AssertEqual(0,   m.Get(0, 1), 0.000001f);
    AssertEqual(0,   m.Get(0, 2), 0.000001f);
    AssertEqual(0,   m.Get(0, 3), 0.000001f);
    AssertEqual(0,   m.Get(1, 0), 0.000001f);
    AssertEqual(0,   m.Get(1, 1), 0.000001f);
    AssertEqual(0,   m.Get(1, 2), 0.000001f);
    AssertEqual(0,   m.Get(1, 3), 0.000001f);
    AssertEqual(118, m.Get(2, 0), 0.000001f);
    AssertEqual(177, m.Get(2, 1), 0.000001f);
    AssertEqual(295, m.Get(2, 2), 0.000001f);
    AssertEqual(413, m.Get(2, 3), 0.000001f);
    AssertEqual(0,   m.Get(3, 0), 0.000001f);
    AssertEqual(0,   m.Get(3, 1), 0.000001f);
    AssertEqual(0,   m.Get(3, 2), 0.000001f);
    AssertEqual(0,   m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_09()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(649,  m.Get(2, 0), 0.000001f);
    AssertEqual(767,  m.Get(2, 1), 0.000001f);
    AssertEqual(1003, m.Get(2, 2), 0.000001f);
    AssertEqual(1121, m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_10()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(1357, m.Get(2, 0), 0.000001f);
    AssertEqual(1711, m.Get(2, 1), 0.000001f);
    AssertEqual(1829, m.Get(2, 2), 0.000001f);
    AssertEqual(2183, m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_11()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(2419, m.Get(2, 0), 0.000001f);
    AssertEqual(2537, m.Get(2, 1), 0.000001f);
    AssertEqual(2773, m.Get(2, 2), 0.000001f);
    AssertEqual(3127, m.Get(2, 3), 0.000001f);
    AssertEqual(0,    m.Get(3, 0), 0.000001f);
    AssertEqual(0,    m.Get(3, 1), 0.000001f);
    AssertEqual(0,    m.Get(3, 2), 0.000001f);
    AssertEqual(0,    m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_12()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,   m.Get(0, 0), 0.000001f);
    AssertEqual(0,   m.Get(0, 1), 0.000001f);
    AssertEqual(0,   m.Get(0, 2), 0.000001f);
    AssertEqual(0,   m.Get(0, 3), 0.000001f);
    AssertEqual(0,   m.Get(1, 0), 0.000001f);
    AssertEqual(0,   m.Get(1, 1), 0.000001f);
    AssertEqual(0,   m.Get(1, 2), 0.000001f);
    AssertEqual(0,   m.Get(1, 3), 0.000001f);
    AssertEqual(0,   m.Get(2, 0), 0.000001f);
    AssertEqual(0,   m.Get(2, 1), 0.000001f);
    AssertEqual(0,   m.Get(2, 2), 0.000001f);
    AssertEqual(0,   m.Get(2, 3), 0.000001f);
    AssertEqual(118, m.Get(3, 0), 0.000001f);
    AssertEqual(177, m.Get(3, 1), 0.000001f);
    AssertEqual(295, m.Get(3, 2), 0.000001f);
    AssertEqual(413, m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_13()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(649,  m.Get(3, 0), 0.000001f);
    AssertEqual(767,  m.Get(3, 1), 0.000001f);
    AssertEqual(1003, m.Get(3, 2), 0.000001f);
    AssertEqual(1121, m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_14()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(1357, m.Get(3, 0), 0.000001f);
    AssertEqual(1711, m.Get(3, 1), 0.000001f);
    AssertEqual(1829, m.Get(3, 2), 0.000001f);
    AssertEqual(2183, m.Get(3, 3), 0.000001f);
}

void MatrixMultiplication_IndividualElements_15()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53);

    // when:
    FbxMatrix b = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59);
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0,    m.Get(0, 0), 0.000001f);
    AssertEqual(0,    m.Get(0, 1), 0.000001f);
    AssertEqual(0,    m.Get(0, 2), 0.000001f);
    AssertEqual(0,    m.Get(0, 3), 0.000001f);
    AssertEqual(0,    m.Get(1, 0), 0.000001f);
    AssertEqual(0,    m.Get(1, 1), 0.000001f);
    AssertEqual(0,    m.Get(1, 2), 0.000001f);
    AssertEqual(0,    m.Get(1, 3), 0.000001f);
    AssertEqual(0,    m.Get(2, 0), 0.000001f);
    AssertEqual(0,    m.Get(2, 1), 0.000001f);
    AssertEqual(0,    m.Get(2, 2), 0.000001f);
    AssertEqual(0,    m.Get(2, 3), 0.000001f);
    AssertEqual(2419, m.Get(3, 0), 0.000001f);
    AssertEqual(2537, m.Get(3, 1), 0.000001f);
    AssertEqual(2773, m.Get(3, 2), 0.000001f);
    AssertEqual(3127, m.Get(3, 3), 0.000001f);
}

void Matrix_ConstructorElements_GetMethodGetsCorrectElements()
{
    // when:
    FbxMatrix m = FbxMatrix(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);

    // then:
    AssertEqual( 1, m.Get(0, 0), 0.000001f);
    AssertEqual( 2, m.Get(0, 1), 0.000001f);
    AssertEqual( 3, m.Get(0, 2), 0.000001f);
    AssertEqual( 4, m.Get(0, 3), 0.000001f);
    AssertEqual( 5, m.Get(1, 0), 0.000001f);
    AssertEqual( 6, m.Get(1, 1), 0.000001f);
    AssertEqual( 7, m.Get(1, 2), 0.000001f);
    AssertEqual( 8, m.Get(1, 3), 0.000001f);
    AssertEqual( 9, m.Get(2, 0), 0.000001f);
    AssertEqual(10, m.Get(2, 1), 0.000001f);
    AssertEqual(11, m.Get(2, 2), 0.000001f);
    AssertEqual(12, m.Get(2, 3), 0.000001f);
    AssertEqual(13, m.Get(3, 0), 0.000001f);
    AssertEqual(14, m.Get(3, 1), 0.000001f);
    AssertEqual(15, m.Get(3, 2), 0.000001f);
    AssertEqual(16, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_00()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual( 22, m.Get(0, 0), 0.000001f);
    AssertEqual( 33, m.Get(0, 1), 0.000001f);
    AssertEqual( 55, m.Get(0, 2), 0.000001f);
    AssertEqual( 77, m.Get(0, 3), 0.000001f);
    AssertEqual( 26, m.Get(1, 0), 0.000001f);
    AssertEqual( 39, m.Get(1, 1), 0.000001f);
    AssertEqual( 65, m.Get(1, 2), 0.000001f);
    AssertEqual( 91, m.Get(1, 3), 0.000001f);
    AssertEqual( 34, m.Get(2, 0), 0.000001f);
    AssertEqual( 51, m.Get(2, 1), 0.000001f);
    AssertEqual( 85, m.Get(2, 2), 0.000001f);
    AssertEqual(119, m.Get(2, 3), 0.000001f);
    AssertEqual( 38, m.Get(3, 0), 0.000001f);
    AssertEqual( 57, m.Get(3, 1), 0.000001f);
    AssertEqual( 95, m.Get(3, 2), 0.000001f);
    AssertEqual(133, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_00()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(279, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_01()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_01()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(279, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_02()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_02()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(279, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_03()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_03()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(279, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_10()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_10()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(279, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_11()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual( 22, m.Get(0, 0), 0.000001f);
    AssertEqual( 33, m.Get(0, 1), 0.000001f);
    AssertEqual( 55, m.Get(0, 2), 0.000001f);
    AssertEqual( 77, m.Get(0, 3), 0.000001f);
    AssertEqual( 26, m.Get(1, 0), 0.000001f);
    AssertEqual( 39, m.Get(1, 1), 0.000001f);
    AssertEqual( 65, m.Get(1, 2), 0.000001f);
    AssertEqual( 91, m.Get(1, 3), 0.000001f);
    AssertEqual( 34, m.Get(2, 0), 0.000001f);
    AssertEqual( 51, m.Get(2, 1), 0.000001f);
    AssertEqual( 85, m.Get(2, 2), 0.000001f);
    AssertEqual(119, m.Get(2, 3), 0.000001f);
    AssertEqual( 38, m.Get(3, 0), 0.000001f);
    AssertEqual( 57, m.Get(3, 1), 0.000001f);
    AssertEqual( 95, m.Get(3, 2), 0.000001f);
    AssertEqual(133, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_11()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(279, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_12()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_12()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(279, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_13()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_13()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(279, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_20()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_20()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(279, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_21()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_21()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(279, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_22()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual( 22, m.Get(0, 0), 0.000001f);
    AssertEqual( 33, m.Get(0, 1), 0.000001f);
    AssertEqual( 55, m.Get(0, 2), 0.000001f);
    AssertEqual( 77, m.Get(0, 3), 0.000001f);
    AssertEqual( 26, m.Get(1, 0), 0.000001f);
    AssertEqual( 39, m.Get(1, 1), 0.000001f);
    AssertEqual( 65, m.Get(1, 2), 0.000001f);
    AssertEqual( 91, m.Get(1, 3), 0.000001f);
    AssertEqual( 34, m.Get(2, 0), 0.000001f);
    AssertEqual( 51, m.Get(2, 1), 0.000001f);
    AssertEqual( 85, m.Get(2, 2), 0.000001f);
    AssertEqual(119, m.Get(2, 3), 0.000001f);
    AssertEqual( 38, m.Get(3, 0), 0.000001f);
    AssertEqual( 57, m.Get(3, 1), 0.000001f);
    AssertEqual( 95, m.Get(3, 2), 0.000001f);
    AssertEqual(133, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_22()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(279, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_23()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_23()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7, 0, 0, 0, 0);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(279, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_30()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_30()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(279, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_31()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_31()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(279, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_32()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_32()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19, 0);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(279, m.Get(3, 2), 0.000001f);
    AssertEqual(0, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyRowsAndColumns_33()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = a * b;

    // then:
    AssertEqual( 22, m.Get(0, 0), 0.000001f);
    AssertEqual( 33, m.Get(0, 1), 0.000001f);
    AssertEqual( 55, m.Get(0, 2), 0.000001f);
    AssertEqual( 77, m.Get(0, 3), 0.000001f);
    AssertEqual( 26, m.Get(1, 0), 0.000001f);
    AssertEqual( 39, m.Get(1, 1), 0.000001f);
    AssertEqual( 65, m.Get(1, 2), 0.000001f);
    AssertEqual( 91, m.Get(1, 3), 0.000001f);
    AssertEqual( 34, m.Get(2, 0), 0.000001f);
    AssertEqual( 51, m.Get(2, 1), 0.000001f);
    AssertEqual( 85, m.Get(2, 2), 0.000001f);
    AssertEqual(119, m.Get(2, 3), 0.000001f);
    AssertEqual( 38, m.Get(3, 0), 0.000001f);
    AssertEqual( 57, m.Get(3, 1), 0.000001f);
    AssertEqual( 95, m.Get(3, 2), 0.000001f);
    AssertEqual(133, m.Get(3, 3), 0.000001f);
}

void Matrix_MultiplyColumnsAndRows_33()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxMatrix a = FbxMatrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 5, 7);
    FbxMatrix b = FbxMatrix(0, 0, 0, 11, 0, 0, 0, 13, 0, 0, 0, 17, 0, 0, 0, 19);

    // when:
    FbxMatrix m = b * a;

    // then:
    AssertEqual(0, m.Get(0, 0), 0.000001f);
    AssertEqual(0, m.Get(0, 1), 0.000001f);
    AssertEqual(0, m.Get(0, 2), 0.000001f);
    AssertEqual(0, m.Get(0, 3), 0.000001f);
    AssertEqual(0, m.Get(1, 0), 0.000001f);
    AssertEqual(0, m.Get(1, 1), 0.000001f);
    AssertEqual(0, m.Get(1, 2), 0.000001f);
    AssertEqual(0, m.Get(1, 3), 0.000001f);
    AssertEqual(0, m.Get(2, 0), 0.000001f);
    AssertEqual(0, m.Get(2, 1), 0.000001f);
    AssertEqual(0, m.Get(2, 2), 0.000001f);
    AssertEqual(0, m.Get(2, 3), 0.000001f);
    AssertEqual(0, m.Get(3, 0), 0.000001f);
    AssertEqual(0, m.Get(3, 1), 0.000001f);
    AssertEqual(0, m.Get(3, 2), 0.000001f);
    AssertEqual(279, m.Get(3, 3), 0.000001f);
}

void MatrixRotationIsCounterClockwiseX()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(90, 0, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);
    FbxVector4 v = FbxVector4();
    FbxVector4 u = FbxVector4();

    // require:
    AssertEqual(1.0, m.Get(0, 0), 0.00001);
    AssertEqual(0.0, m.Get(0, 1), 0.00001);
    AssertEqual(0.0, m.Get(0, 2), 0.00001);
    AssertEqual(0.0, m.Get(0, 3), 0.00001);
    AssertEqual(0.0, m.Get(1, 0), 0.00001);
    AssertEqual(0.0, m.Get(1, 1), 0.00001);
    AssertEqual(1.0, m.Get(1, 2), 0.00001);
    AssertEqual(0.0, m.Get(1, 3), 0.00001);
    AssertEqual(0.0, m.Get(2, 0), 0.00001);
    AssertEqual(-1.0,m.Get(2, 1), 0.00001);
    AssertEqual(0.0, m.Get(2, 2), 0.00001);
    AssertEqual(0.0, m.Get(2, 3), 0.00001);
    AssertEqual(0.0, m.Get(3, 0), 0.00001);
    AssertEqual(0.0, m.Get(3, 1), 0.00001);
    AssertEqual(0.0, m.Get(3, 2), 0.00001);
    AssertEqual(1.0, m.Get(3, 3), 0.00001);

    // when:
    v = FbxVector4(0, 0, 1, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual(-1, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);

    // when:
    v = FbxVector4(0, 1, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual( 1, u[2], 0.000001f);

    // when:
    v = FbxVector4(0, 0, -1, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual( 1, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);

    // when:
    v = FbxVector4(0, -1, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual(-1, u[2], 0.000001f);
}

void MatrixRotationIsCounterClockwiseY()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 90, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);
    FbxVector4 v = FbxVector4();
    FbxVector4 u = FbxVector4();

    // require:
    AssertEqual(0.0, m.Get(0, 0), 0.00001);
    AssertEqual(0.0, m.Get(0, 1), 0.00001);
    AssertEqual(-1.0,m.Get(0, 2), 0.00001);
    AssertEqual(0.0, m.Get(0, 3), 0.00001);
    AssertEqual(0.0, m.Get(1, 0), 0.00001);
    AssertEqual(1.0, m.Get(1, 1), 0.00001);
    AssertEqual(0.0, m.Get(1, 2), 0.00001);
    AssertEqual(0.0, m.Get(1, 3), 0.00001);
    AssertEqual(1.0, m.Get(2, 0), 0.00001);
    AssertEqual(0.0, m.Get(2, 1), 0.00001);
    AssertEqual(0.0, m.Get(2, 2), 0.00001);
    AssertEqual(0.0, m.Get(2, 3), 0.00001);
    AssertEqual(0.0, m.Get(3, 0), 0.00001);
    AssertEqual(0.0, m.Get(3, 1), 0.00001);
    AssertEqual(0.0, m.Get(3, 2), 0.00001);
    AssertEqual(1.0, m.Get(3, 3), 0.00001);

    // when:
    v = FbxVector4(0, 0, 1, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 1, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);

    // when:
    v = FbxVector4(1, 0, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual(-1, u[2], 0.000001f);

    // when:
    v = FbxVector4(0, 0, -1, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual(-1, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);

    // when:
    v = FbxVector4(-1, 0, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual( 1, u[2], 0.000001f);
}

void MatrixRotationIsCounterClockwiseZ()
{
    // given:
    FbxManager* manager = FbxManager::Create();
    FbxVector4 t = FbxVector4(0, 0, 0);
    FbxVector4 r = FbxVector4(0, 0, 90);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m = FbxMatrix(t, r, s);
    FbxVector4 v = FbxVector4();
    FbxVector4 u = FbxVector4();

    // require:
    AssertEqual(0.0, m.Get(0, 0), 0.00001);
    AssertEqual(1.0, m.Get(0, 1), 0.00001);
    AssertEqual(0.0, m.Get(0, 2), 0.00001);
    AssertEqual(0.0, m.Get(0, 3), 0.00001);
    AssertEqual(-1.0,m.Get(1, 0), 0.00001);
    AssertEqual(0.0, m.Get(1, 1), 0.00001);
    AssertEqual(0.0, m.Get(1, 2), 0.00001);
    AssertEqual(0.0, m.Get(1, 3), 0.00001);
    AssertEqual(0.0, m.Get(2, 0), 0.00001);
    AssertEqual(0.0, m.Get(2, 1), 0.00001);
    AssertEqual(1.0, m.Get(2, 2), 0.00001);
    AssertEqual(0.0, m.Get(2, 3), 0.00001);
    AssertEqual(0.0, m.Get(3, 0), 0.00001);
    AssertEqual(0.0, m.Get(3, 1), 0.00001);
    AssertEqual(0.0, m.Get(3, 2), 0.00001);
    AssertEqual(1.0, m.Get(3, 3), 0.00001);

    // when:
    v = FbxVector4(1, 0, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual( 1, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);

    // when:
    v = FbxVector4(0, 1, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual(-1, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);

    // when:
    v = FbxVector4(-1, 0, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 0, u[0], 0.000001f);
    AssertEqual(-1, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);

    // when:
    v = FbxVector4(0, -1, 0, 1);
    u = m.MultNormalize(v);

    // then:
    AssertEqual( 1, u[0], 0.000001f);
    AssertEqual( 0, u[1], 0.000001f);
    AssertEqual( 0, u[2], 0.000001f);
}

void MatrixMultiplyTransformOrder_TransformationsOccurRightToLeft()
{

    /*;
    transforming v by (m1 * m2) is equivalent to transforming v by m2, and;
    // then:
    */;

    // given:
    FbxManager* manager = FbxManager::Create();
    FbxVector4 t1 = FbxVector4(1, 0, 0);
    FbxVector4 t2 = FbxVector4(0, 0, 0);
    FbxVector4 r1 = FbxVector4(0, 0, 0);
    FbxVector4 r2 = FbxVector4(0, 90, 0);
    FbxVector4 s = FbxVector4(1, 1, 1);
    FbxMatrix m1 = FbxMatrix(t1, r1, s);
    FbxMatrix m2 = FbxMatrix(t2, r2, s);
    FbxVector4 u = FbxVector4();
    FbxVector4 zero = FbxVector4(0, 0, 0, 1);
    FbxVector4 one = FbxVector4(1, 1, 1, 1);
    FbxVector4 x = FbxVector4(1, 0, 0, 1);
    FbxVector4 y = FbxVector4(0, 1, 0, 1);
    FbxVector4 z = FbxVector4(0, 0, 1, 1);

    // require:
    u = m1.MultNormalize(zero);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m1.MultNormalize(x);
    AssertEqual(2, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m1.MultNormalize(y);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m1.MultNormalize(z);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(1, u[2], 0.000001f);
    u = m1.MultNormalize(one);
    AssertEqual(2, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(1, u[2], 0.000001f);

    u = m2.MultNormalize(zero);
    AssertEqual(0, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m2.MultNormalize(x);
    AssertEqual(0, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(-1,u[2], 0.000001f);
    u = m2.MultNormalize(y);
    AssertEqual(0, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m2.MultNormalize(z);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m2.MultNormalize(one);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(-1,u[2], 0.000001f);

    // when:
    FbxMatrix m = m1 * m2;

    // then:
    u = m.MultNormalize(zero);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m.MultNormalize(x);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(-1,u[2], 0.000001f);
    u = m.MultNormalize(y);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m.MultNormalize(z);
    AssertEqual(2, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(0, u[2], 0.000001f);
    u = m.MultNormalize(one);
    AssertEqual(2, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(-1,u[2], 0.000001f);

    // when:
    m = m2 * m1;

    // then:
    u = m.MultNormalize(zero);
    AssertEqual(0, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(-1,u[2], 0.000001f);
    u = m.MultNormalize(x);
    AssertEqual(0, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(-2,u[2], 0.000001f);
    u = m.MultNormalize(y);
    AssertEqual(0, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(-1,u[2], 0.000001f);
    u = m.MultNormalize(z);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(0, u[1], 0.000001f);
    AssertEqual(-1,u[2], 0.000001f);
    u = m.MultNormalize(one);
    AssertEqual(1, u[0], 0.000001f);
    AssertEqual(1, u[1], 0.000001f);
    AssertEqual(-2,u[2], 0.000001f);
}

void MatrixTest::RegisterTestCases()
{
    AddTestCase(Matrix_TrsConstructorNoTransforms_CreatesIdentity);
    AddTestCase(Matrix_TrsConstructorTranslation_CreatesWithTranslation);
    AddTestCase(Matrix_TrsConstructorRotationX_CreatesWithRotationX);
    AddTestCase(Matrix_TrsConstructorRotationY_CreatesWithRotationY);
    AddTestCase(Matrix_TrsConstructorRotationZ_CreatesWithRotationZ);
    AddTestCase(Matrix_TrsConstructorRotationXY_CreatesWithRotationXY);
    AddTestCase(Matrix_TrsConstructorRotationYZ_CreatesWithRotationYZ);
    AddTestCase(Matrix_TrsConstructorRotationXZ_CreatesWithRotationXZ);
    AddTestCase(Matrix_TrsConstructorRotationXYZ_CreatesWithRotationXYZ);
    AddTestCase(Matrix_TrsConstructorScale_CreatesWithScale);
    AddTestCase(Matrix_TrsConstructorEverything_CreatesMatrix);
    AddTestCase(Matrix_Multiply);
    AddTestCase(Matrix_Multiply_2);
    AddTestCase(Matrix_Multiply_3);
    AddTestCase(Matrix_MultiplicationIsAssociative);
    AddTestCase(MatrixMultiplication_IndividualElements_00);
    AddTestCase(MatrixMultiplication_IndividualElements_01);
    AddTestCase(MatrixMultiplication_IndividualElements_02);
    AddTestCase(MatrixMultiplication_IndividualElements_03);
    AddTestCase(MatrixMultiplication_IndividualElements_04);
    AddTestCase(MatrixMultiplication_IndividualElements_05);
    AddTestCase(MatrixMultiplication_IndividualElements_06);
    AddTestCase(MatrixMultiplication_IndividualElements_07);
    AddTestCase(MatrixMultiplication_IndividualElements_08);
    AddTestCase(MatrixMultiplication_IndividualElements_09);
    AddTestCase(MatrixMultiplication_IndividualElements_10);
    AddTestCase(MatrixMultiplication_IndividualElements_11);
    AddTestCase(MatrixMultiplication_IndividualElements_12);
    AddTestCase(MatrixMultiplication_IndividualElements_13);
    AddTestCase(MatrixMultiplication_IndividualElements_14);
    AddTestCase(MatrixMultiplication_IndividualElements_15);
    AddTestCase(Matrix_ConstructorElements_GetMethodGetsCorrectElements);
    AddTestCase(Matrix_MultiplyRowsAndColumns_00);
    AddTestCase(Matrix_MultiplyColumnsAndRows_00);
    AddTestCase(Matrix_MultiplyRowsAndColumns_01);
    AddTestCase(Matrix_MultiplyColumnsAndRows_01);
    AddTestCase(Matrix_MultiplyRowsAndColumns_02);
    AddTestCase(Matrix_MultiplyColumnsAndRows_02);
    AddTestCase(Matrix_MultiplyRowsAndColumns_03);
    AddTestCase(Matrix_MultiplyColumnsAndRows_03);
    AddTestCase(Matrix_MultiplyRowsAndColumns_10);
    AddTestCase(Matrix_MultiplyColumnsAndRows_10);
    AddTestCase(Matrix_MultiplyRowsAndColumns_11);
    AddTestCase(Matrix_MultiplyColumnsAndRows_11);
    AddTestCase(Matrix_MultiplyRowsAndColumns_12);
    AddTestCase(Matrix_MultiplyColumnsAndRows_12);
    AddTestCase(Matrix_MultiplyRowsAndColumns_13);
    AddTestCase(Matrix_MultiplyColumnsAndRows_13);
    AddTestCase(Matrix_MultiplyRowsAndColumns_20);
    AddTestCase(Matrix_MultiplyColumnsAndRows_20);
    AddTestCase(Matrix_MultiplyRowsAndColumns_21);
    AddTestCase(Matrix_MultiplyColumnsAndRows_21);
    AddTestCase(Matrix_MultiplyRowsAndColumns_22);
    AddTestCase(Matrix_MultiplyColumnsAndRows_22);
    AddTestCase(Matrix_MultiplyRowsAndColumns_23);
    AddTestCase(Matrix_MultiplyColumnsAndRows_23);
    AddTestCase(Matrix_MultiplyRowsAndColumns_30);
    AddTestCase(Matrix_MultiplyColumnsAndRows_30);
    AddTestCase(Matrix_MultiplyRowsAndColumns_31);
    AddTestCase(Matrix_MultiplyColumnsAndRows_31);
    AddTestCase(Matrix_MultiplyRowsAndColumns_32);
    AddTestCase(Matrix_MultiplyColumnsAndRows_32);
    AddTestCase(Matrix_MultiplyRowsAndColumns_33);
    AddTestCase(Matrix_MultiplyColumnsAndRows_33);
    AddTestCase(MatrixRotationIsCounterClockwiseX);
    AddTestCase(MatrixRotationIsCounterClockwiseY);
    AddTestCase(MatrixRotationIsCounterClockwiseZ);
    AddTestCase(MatrixMultiplyTransformOrder_TransformationsOccurRightToLeft);
}

