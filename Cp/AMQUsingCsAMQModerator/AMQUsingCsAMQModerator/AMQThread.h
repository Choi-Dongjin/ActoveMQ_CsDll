#pragma once
#include "AMQDatas.h"
#include "AMQModerator.h"
#include <Windows.h>
#include <chrono>
#include <ctime>
#include <iomanip>
#include <iostream>
#include <sstream>
#include <string>

namespace ActiveMQC {
	enum THREAD_STATE
	{
		THREAD_STATE_IDLE,      // 스레드가 대기 중인 상태
		THREAD_STATE_RUNNING,   // 스레드가 실행 중인 상태
		THREAD_STATE_STOPPED    // 스레드가 중지된 상태
	};

	class AMQThread : public CWinThread
	{
		DECLARE_DYNCREATE(AMQThread)
	public:
		AMQThread();
		~AMQThread();

		virtual BOOL InitInstance(const char* _brokerUri, const char* _destinationName);

		virtual int ExitInstance();

		virtual int Run();

		void RequestTerminate();

		THREAD_STATE GetThreadState();

	private:
		BOOL bTerminateRequested;
		THREAD_STATE ThreadState;
		CRITICAL_SECTION CriticalSection;
		ActiveMQModeratorManager* _amqModeratorManager;

		const char* _brokerUri;
		const char* _destinationName;
	};
}
