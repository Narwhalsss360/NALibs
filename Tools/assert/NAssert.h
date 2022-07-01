#ifndef NAssert_h
#define NAssert_h

#include <assert.h>

#define nassert(expression, message, printer) (expression) ? (void)0 : __nassert__(printer, __FILE__, __LINE__, __TIMESTAMP__, message, #expression)
#define snassert(expression, message) nassert(expression, message, &Serial)

bool __pass_nassert__ = false;

void __nassert__(Print* output, const char* __file__, int __line__, const char* __timestamp__, const char* message, const char* exp)
{
    output->flush();
    output->println();

    output->print("Assertion at ");
    output->print(__file__);
    output->print(" line ");
    output->print(__line__);
    output->print(", Pre-processor time: ");
    output->println(__timestamp__);

    output->print("    \"");
    output->print(exp);
    output->print("\" Failed,\n    ");

    output->println(message);

#ifdef __NASSERT_TIME_F__
    output->print("Time of assertion: ");
    output->println(__NASSERT_TIME_F__());
#endif

#ifdef __NASSERT_ENSURE__
    __NASSERT_ENSURE__
#endif

    output->flush();

#ifndef __PASS_NASSERT__
    if (!__pass_nassert__)
        abort();
#endif
}

#endif