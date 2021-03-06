#include <jni.h>
#include <stddef.h>
#include "InitParams.h"
#include "JniCallbackList.h"
#include "OpenHome/Net/C/OhNet.h"

#ifdef __cplusplus
extern "C" {
#endif

static void STDCALL CallbackMessage(void* aPtr, const char* aMsg)
{
    JniObjRef *ref = (JniObjRef*) aPtr;
    JavaVM *vm = ref->vm;
    jint ret;
    JNIEnv *env;
    jclass cls;
    jmethodID mid;
    jstring msg;
    jint attached;

    attached = (*vm)->GetEnv(vm, (void **)&env, JNI_VERSION_1_4);
    if (attached < 0)
    {
#ifdef __ANDROID__
        ret = (*vm)->AttachCurrentThreadAsDaemon(vm, &env, NULL);
#else
        ret = (*vm)->AttachCurrentThreadAsDaemon(vm, (void **)&env, NULL);
#endif
        if (ret < 0)
        {
            printf("InitParamsJNI: Unable to attach thread to JVM.\n");
            fflush(stdout);
            return;
        }
    }
    cls = (*env)->GetObjectClass(env, ref->callbackObj);
    mid = (*env)->GetMethodID(env, cls, "message", "(Ljava/lang/String;)V");
    if (mid == 0) {
        printf("Method ID message() not found.\n");
        return;
    }
    msg = (*env)->NewStringUTF(env, aMsg);
    (*env)->CallVoidMethod(env, ref->callbackObj, mid, msg);

    // leave daemon thread attached to the VM
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsCreate
 * Signature: ()J
 */
JNIEXPORT jlong JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsCreate
  (JNIEnv *aEnv, jclass aClass)
{
	aEnv = aEnv;
	aClass = aClass;
	
	return (jlong) (size_t)OhNetInitParamsCreate();
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDestroy
 * Signature: (J)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDestroy
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsDestroy(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsTcpConnectTimeoutMs
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsTcpConnectTimeoutMs
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsTcpConnectTimeoutMs(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsMsearchTimeSecs
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsMsearchTimeSecs
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsMsearchTimeSecs(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsMsearchTtl
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsMsearchTtl
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsMsearchTtl(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsNumEventSessionThreads
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsNumEventSessionThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsNumEventSessionThreads(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsNumXmlFetcherThreads
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsNumXmlFetcherThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsNumXmlFetcherThreads(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsNumActionInvokerThreads
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsNumActionInvokerThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsNumActionInvokerThreads(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsNumInvocations
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsNumInvocations
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsNumInvocations(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsNumSubscriberThreads
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsNumSubscriberThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsNumSubscriberThreads(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsPendingSubscriptionTimeoutMs
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsPendingSubscriptionTimeoutMs
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsPendingSubscriptionTimeoutMs(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDvMaxUpdateTimeSecs
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDvMaxUpdateTimeSecs
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsDvMaxUpdateTimeSecs(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDvNumServerThreads
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDvNumServerThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsDvNumServerThreads(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDvNumPublisherThreads
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDvNumPublisherThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsDvNumPublisherThreads(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDvNumWebSocketThreads
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDvNumWebSocketThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsDvNumWebSocketThreads(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDvUpnpServerPort
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDvUpnpServerPort
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsDvUpnpServerPort(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDvWebSocketPort
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDvWebSocketPort
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsDvWebSocketPort(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsDvIsBonjourEnabled
 * Signature: (J)I
 */
JNIEXPORT jint JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsDvIsBonjourEnabled
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	return (jint) OhNetInitParamsDvIsBonjourEnabled(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetTcpConnectTimeout
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetTcpConnectTimeout
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aTimeoutMs)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetTcpConnectTimeout(params, aTimeoutMs);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetMsearchTime
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetMsearchTime
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aSecs)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetMsearchTime(params, aSecs);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetMsearchTtl
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetMsearchTtl
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aTtl)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetMsearchTtl(params, aTtl);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetNumEventSessionThreads
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetNumEventSessionThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumThreads)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetNumEventSessionThreads(params, aNumThreads);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetNumXmlFetcherThreads
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetNumXmlFetcherThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumThreads)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetNumXmlFetcherThreads(params, aNumThreads);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetNumActionInvokerThreads
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetNumActionInvokerThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumThreads)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetNumActionInvokerThreads(params, aNumThreads);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetNumInvocations
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetNumInvocations
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumInvocations)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetNumInvocations(params, aNumInvocations);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetNumSubscriberThreads
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetNumSubscriberThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumThreads)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetNumSubscriberThreads(params, aNumThreads);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetPendingSubscriptionTimeout
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetPendingSubscriptionTimeout
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aTimeoutMs)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetPendingSubscriptionTimeout(params, aTimeoutMs);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetUseLoopbackNetworkAdapter
 * Signature: (J)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetUseLoopbackNetworkAdapter
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetUseLoopbackNetworkAdapter(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetDvMaxUpdateTime
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetDvMaxUpdateTime
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aSecs)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetDvMaxUpdateTime(params, aSecs);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetDvNumServerThreads
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetDvNumServerThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumThreads)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetDvNumServerThreads(params, aNumThreads);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetDvNumPublisherThreads
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetDvNumPublisherThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumThreads)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetDvNumPublisherThreads(params, aNumThreads);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetDvNumWebSocketThreads
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetDvNumWebSocketThreads
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aNumThreads)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetDvNumWebSocketThreads(params, aNumThreads);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetDvUpnpServerPort
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetDvUpnpServerPort
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aPort)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetDvUpnpServerPort(params, aPort);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetDvWebSocketPort
 * Signature: (JI)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetDvWebSocketPort
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jint aPort)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetDvWebSocketPort(params, aPort);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetDvEnableBonjour
 * Signature: (J)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetDvEnableBonjour
  (JNIEnv *aEnv, jclass aClass, jlong aParams)
{
	OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
	aEnv = aEnv;
	aClass = aClass;
	
	OhNetInitParamsSetDvEnableBonjour(params);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetLogOutput
 * Signature: (JLorg/openhome/net/core/IMessageListener;)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetLogOutput
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jobject aListener)
{
    OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
    OhNetCallbackMsg callback = (OhNetCallbackMsg) &CallbackMessage;
    JniObjRef *ref = (JniObjRef*) malloc(sizeof(JniObjRef));
    int ret;
    aClass = aClass;

    ret = (*aEnv)->GetJavaVM(aEnv, &ref->vm);
    if (ret < 0) {
        printf("Unable to get reference to the current Java VM.\n");
    }
    ref->callbackObj = (*aEnv)->NewGlobalRef(aEnv, aListener);
    
    OhNetInitParamsSetLogOutput(params, callback, ref);
}

/*
 * Class:     org_openhome_net_core_InitParams
 * Method:    OhNetInitParamsSetFatalErrorHandler
 * Signature: (JLorg/openhome/net/core/IMessageListener;)V
 */
JNIEXPORT void JNICALL Java_org_openhome_net_core_InitParams_OhNetInitParamsSetFatalErrorHandler
  (JNIEnv *aEnv, jclass aClass, jlong aParams, jobject aListener)
{
    OhNetHandleInitParams params = (OhNetHandleInitParams) (size_t)aParams;
    OhNetCallbackMsg callback = (OhNetCallbackMsg) &CallbackMessage;
    JniObjRef *ref = (JniObjRef*) malloc(sizeof(JniObjRef));
    int ret;
    aClass = aClass;

    ret = (*aEnv)->GetJavaVM(aEnv, &ref->vm);
    if (ret < 0) {
        printf("Unable to get reference to the current Java VM.\n");
    }
    ref->callbackObj = (*aEnv)->NewGlobalRef(aEnv, aListener);
    
    OhNetInitParamsSetFatalErrorHandler(params, callback, ref);
}

#ifdef __cplusplus
}
#endif
