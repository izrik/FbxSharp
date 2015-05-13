
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
}

