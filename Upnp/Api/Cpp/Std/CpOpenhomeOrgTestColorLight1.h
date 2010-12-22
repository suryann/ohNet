#ifndef HEADER_OPENHOMEORGTESTCOLORLIGHT1CPP
#define HEADER_OPENHOMEORGTESTCOLORLIGHT1CPP

#include <ZappTypes.h>
#include <Exception.h>
#include <Functor.h>
#include <FunctorAsync.h>
#include <CpProxy.h>

#include <string>

namespace Zapp {

class CpDeviceCpp;
class Action;
class PropertyBinary;
class PropertyBool;
class PropertyInt;
class PropertyString;
class PropertyUint;

/**
 * Proxy for openhome.org:TestColorLight:1
 * @ingroup Proxies
 */
class CpProxyOpenhomeOrgTestColorLight1Cpp : public CpProxy
{
public:
    /**
     * Constructor.
     *
     * Use CpProxy::[Un]Subscribe() to enable/disable querying of state variable
     * and reporting of their changes.
     *
     * @param[in]  aDevice   The device to use
     */
    CpProxyOpenhomeOrgTestColorLight1Cpp(CpDeviceCpp& aDevice);
    /**
     * Destructor.
     * If any asynchronous method is in progress, this will block until they complete.
     * [Note that any methods still in progress are likely to complete with an error.]
     * Clients who have called Subscribe() do not need to call Unsubscribe() before
     * calling delete.  An unsubscribe will be triggered automatically when required.
     */
    ~CpProxyOpenhomeOrgTestColorLight1Cpp();

    /**
     * Invoke the action synchronously.  Blocks until the action has been processed
     * on the device and sets any output arguments.
     *
     * @param[out] aFriendlyName
     */
    void SyncGetName(std::string& aFriendlyName);
    /**
     * Invoke the action asynchronously.
     * Returns immediately and will run the client-specified callback when the action
     * later completes.  Any output arguments can then be retrieved by calling
     * EndGetName().
     *
     * @param[in] aFunctor   Callback to run when the action completes.
     *                       This is guaranteed to be run but may indicate an error
     */
    void BeginGetName(FunctorAsync& aFunctor);
    /**
     * Retrieve the output arguments from an asynchronously invoked action.
     * This may only be called from the callback set in the above Begin function.
     *
     * @param[in]  aAsync  Argument passed to the callback set in the above Begin function
     * @param[out] aFriendlyName
     */
    void EndGetName(IAsync& aAsync, std::string& aFriendlyName);

    /**
     * Invoke the action synchronously.  Blocks until the action has been processed
     * on the device and sets any output arguments.
     *
     * @param[in]  aRed
     * @param[in]  aGreen
     * @param[in]  aBlue
     */
    void SyncSetColor(uint32_t aRed, uint32_t aGreen, uint32_t aBlue);
    /**
     * Invoke the action asynchronously.
     * Returns immediately and will run the client-specified callback when the action
     * later completes.  Any output arguments can then be retrieved by calling
     * EndSetColor().
     *
     * @param[in] aRed
     * @param[in] aGreen
     * @param[in] aBlue
     * @param[in] aFunctor   Callback to run when the action completes.
     *                       This is guaranteed to be run but may indicate an error
     */
    void BeginSetColor(uint32_t aRed, uint32_t aGreen, uint32_t aBlue, FunctorAsync& aFunctor);
    /**
     * Retrieve the output arguments from an asynchronously invoked action.
     * This may only be called from the callback set in the above Begin function.
     *
     * @param[in]  aAsync  Argument passed to the callback set in the above Begin function
     */
    void EndSetColor(IAsync& aAsync);

    /**
     * Invoke the action synchronously.  Blocks until the action has been processed
     * on the device and sets any output arguments.
     *
     * @param[out] aRed
     * @param[out] aGreen
     * @param[out] aBlue
     */
    void SyncGetColor(uint32_t& aRed, uint32_t& aGreen, uint32_t& aBlue);
    /**
     * Invoke the action asynchronously.
     * Returns immediately and will run the client-specified callback when the action
     * later completes.  Any output arguments can then be retrieved by calling
     * EndGetColor().
     *
     * @param[in] aFunctor   Callback to run when the action completes.
     *                       This is guaranteed to be run but may indicate an error
     */
    void BeginGetColor(FunctorAsync& aFunctor);
    /**
     * Retrieve the output arguments from an asynchronously invoked action.
     * This may only be called from the callback set in the above Begin function.
     *
     * @param[in]  aAsync  Argument passed to the callback set in the above Begin function
     * @param[out] aRed
     * @param[out] aGreen
     * @param[out] aBlue
     */
    void EndGetColor(IAsync& aAsync, uint32_t& aRed, uint32_t& aGreen, uint32_t& aBlue);

    /**
     * Invoke the action synchronously.  Blocks until the action has been processed
     * on the device and sets any output arguments.
     *
     * @param[out] aRed
     * @param[out] aGreen
     * @param[out] aBlue
     */
    void SyncGetMaxColors(uint32_t& aRed, uint32_t& aGreen, uint32_t& aBlue);
    /**
     * Invoke the action asynchronously.
     * Returns immediately and will run the client-specified callback when the action
     * later completes.  Any output arguments can then be retrieved by calling
     * EndGetMaxColors().
     *
     * @param[in] aFunctor   Callback to run when the action completes.
     *                       This is guaranteed to be run but may indicate an error
     */
    void BeginGetMaxColors(FunctorAsync& aFunctor);
    /**
     * Retrieve the output arguments from an asynchronously invoked action.
     * This may only be called from the callback set in the above Begin function.
     *
     * @param[in]  aAsync  Argument passed to the callback set in the above Begin function
     * @param[out] aRed
     * @param[out] aGreen
     * @param[out] aBlue
     */
    void EndGetMaxColors(IAsync& aAsync, uint32_t& aRed, uint32_t& aGreen, uint32_t& aBlue);


private:
private:
    Action* iActionGetName;
    Action* iActionSetColor;
    Action* iActionGetColor;
    Action* iActionGetMaxColors;
};

} // namespace Zapp

#endif // HEADER_OPENHOMEORGTESTCOLORLIGHT1CPP
