// AMQUsingCsAMQModerator.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <Windows.h>
#include <string.h>    //strcmp
#include "json/json.h"
#include "AMQModerator.h"
#include "AMQDatas.h";

#define NAME_OF( name ) ((void) sizeof(typeid(name)), #name)

int main() {
	char* brokerUri = (char*)"tcp://localhost:61616"; // 브로커 접속 URL
	char* destinationName = (char*)"queue://queueTest"; // Q 접속시 사용
	//char* topicName = (char*)"topic://topicTest"; // Topic 접속시 사용

	ActiveMQC::AMQModerator amqModerator = { brokerUri, destinationName };
	if (!amqModerator.Initialize()) {
		std::cout << "AMQModerator Initialize False" << std::endl;
		return 1;
	}

	if (!amqModerator.TESTInitSendMess_AIRQ()) {
		std::cout << "AMQModerator TESTInitSendMess_AIRQ False" << std::endl;
		return 1;
	}

	char* receiveMessage = amqModerator.ReceiveMessage();
	if (strcmp(receiveMessage, "False Value") == 0) {
		// 입력 인자 불량, 입력 인자를 True로 설정
	}
	else if (strcmp(receiveMessage, "Main.consumer is not Init") == 0) {
		// 초기화 실패 라이브러리 확인
	}
	else if (strcmp(receiveMessage, "Null mess") == 0) {
		// 수신 mess 불량, 관리자에 문의
	}

	Json::Value receiveData;
	Json::Reader reader;
	bool parsingSuccessful = reader.parse(receiveMessage, receiveData);
	if (!parsingSuccessful)
	{
		std::cout << "Error parsing the string" << std::endl;
	}

	ActiveMQCData::DataAIRQ data;
	data.MagicSetValue(receiveData);

	ActiveMQCData::DataAIRS dataAIRS = { data, "TESTDATA", "TESTDATA" , "TESTDATA" , "TESTDATA" , "TESTDATA" , "TESTDATA" , "TESTDATA" };

	ActiveMQCData::DataAIRSResultInfo dataAIRSResultInfo = { "TESTDATA", "TESTDATA", "TESTDATA" };
	dataAIRSResultInfo.AddSynapseRuleResult("Key1", "TESTDATA", "TESTDATA", "TESTDATA");
	dataAIRSResultInfo.AddSynapseDefectItem("Key1", "TESTDATA", "TESTDATA", "TESTDATA", "TESTDATA", "TESTDATA", "TESTDATA", "TESTDATA", "TESTDATA");
	dataAIRS.SetResultInfo(dataAIRSResultInfo);
	std::cout << dataAIRS.Tostring() << std::endl;

	//std::string name = "TEST";
	//std::string dd = NAME_OF(name);
	//std::cout << dd << std::endl;
	//std::cout << dd.length() << std::endl;
	amqModerator.~AMQModerator();
}

/// <summary>
/// 따로 동작 TEST
/// </summary>
/// <returns></returns>
int main1()
{
	HMODULE hActiveMQModerator;
	hActiveMQModerator = LoadLibraryA("AMQModerator.dll");

#pragma region Common
	bool (*pBrokerUrlIsLive)(char*); // 브로커 URL 접속 가능 여부 확인 메서드

	pBrokerUrlIsLive = (bool (*)(char*))(GetProcAddress(hActiveMQModerator, "BrokerUriIsLive")); // null, 예외 처리 필요.
	if (pBrokerUrlIsLive == 0) {
		std::cout << "pBrokerUrlIsLive Ini : False" << std::endl;
		return 0;
	}
	/* pBrokerUriIsLive
	* 입력 인자 (char* [브로커 URL]
	*	[브로커 URL]
	*		ActiveMQ 브로커 서버 URL 입력
	*
	* return 값
	*	trun : 접속 가능
	*	false : 접속 불가능
	*/
#pragma endregion

#pragma region Producer
	bool (*pProducerInitialize)(char*, char*); // 생산자 초기화 메서드
	bool (*pProducerSendMessage)(char*); // 메세지 전송 메서드
	bool (*pProducerDispose)(bool); // 생산자 인스턴스 메모리 초기화 메서드

	pProducerInitialize = (bool (*)(char*, char*))(GetProcAddress(hActiveMQModerator, "ProducerInitialize")); // null, 예외처리 필요.
	if (pProducerInitialize == 0) {
		std::cout << "pProducerInitialize Ini : False" << std::endl;
		return 0;
	}
	/*  pProducerInitialize
	* 입력 인자 (char* [브로커 URL], char* [Queue, Topic URL]
	*	[브로커 URL]
	*		ActiveMQ 브로커 서버 URL 입력
	*	[Queue, Topic URL]
	*		Queue 혹은 Topic 경로 입력
	*		Queue 에 접속하는 경우 : queue:// 을 앞에 명기
	*		Topic 에 접속하는 경우 : topic:// 을 앞에 명기
	*
	* return 값
	*	true : 초기화 성공
	*	false : 초기화 실패 - 입력 URL 확인, 서버 접속 유무 확인
	*/
	pProducerSendMessage = (bool (*)(char*))(GetProcAddress(hActiveMQModerator, "ProducerSendMessage")); // null, 예외처리 필요.
	if (pProducerSendMessage == 0) {
		std::cout << "pProducerSendMessage Ini : False" << std::endl;
		return 0;
	}
	/* pProducerSendMessage
	* 입력 인자 (char* [전송 데이터]
	*	[전송 데이터]
	*		초기화된 정보에 따라 Queue or Topic에 데이터 전송
	*
	* return 값
	*	true : 전송 성공
	*	false : 전송 실패 - 초기화 확인, 접속 유무 확인,
	*/
	pProducerDispose = (bool (*)(bool))(GetProcAddress(hActiveMQModerator, "ProducerDispose")); // null, 예외처리 필요.
	if (pProducerDispose == 0) {
		std::cout << "pProducerDispose Ini : False" << std::endl;
		return 0;
	}
	/* pProducerDispose
	* 입력 인자 (bool [실행 유무])
	*	[실행 유무]
	*		true 유지
	*
	* return 값
	*	true : 종료 완료
	*	false : 종료 실패
	*/
#pragma endregion

#pragma region Consumer
	bool (*pConsumerInitialize)(char*, char*); // 소비자 초기화 메서드
	char* (*pConsumerReceiveMessage)(bool); // 소비자 데이터 수신 메서드
	char* (*pConsumerGetAllReceiveMessages)(bool); // 소비자 남아있는 데이터 한번에 수신 메서드
	bool (*pClearAllMessages)(bool); // 데이터 초기화
	bool (*pConsumerDispose)(bool); // 소비자 인스턴스 메모리 초기화 메서드

	pConsumerInitialize = (bool (*)(char*, char*))(GetProcAddress(hActiveMQModerator, "ConsumerInitialize")); // null, 예외처리 필요.
	if (pConsumerInitialize == 0) {
		std::cout << "pConsumerInitialize Ini : False" << std::endl;
		return 0;
	}
	/*  pConsumerInitialize
	* 입력 인자 (char* [브로커 URL], char* [Queue, Topic URL]
	*	[브로커 URL]
	*		ActiveMQ 브로커 서버 URL 입력
	*	[Queue, Topic URL]
	*		Queue 혹은 Topic 경로 입력
	*		Queue 에 접속하는 경우 : queue:// 을 앞에 명기
	*		Topic 에 접속하는 경우 : topic:// 을 앞에 명기
	*
	* return 값
	*	true : 초기화 성공
	*	false : 초기화 실패 - 입력 URL 확인, 서버 접속 유무 확인
	*/
	pConsumerReceiveMessage = (char* (*)(bool))(GetProcAddress(hActiveMQModerator, "ConsumerReceiveMessage")); // null, 예외처리 필요.
	if (pConsumerReceiveMessage == 0) {
		std::cout << "pConsumerReceiveMessage Ini : False" << std::endl;
		return 0;
	}
	/* pProducerSendMessage
	* 입력 인자 (bool [실행 유무])
	*	[실행 유무]
	*		true 유지
	*
	* return 값
	*	수신 성공 - 브로커에서 수신된 데이터
	*	수신 실패
	*		- "False Value" : 입력값에 flase을 입력.
	*		- "Main.consumer is not Init" : 소비자 초기화 안됨.
	*		- "Null mess" : 리던값이 null
	*		- "오류 메시지" : Dll 오류.
	*/
	pConsumerGetAllReceiveMessages = (char* (*)(bool))(GetProcAddress(hActiveMQModerator, "ConsumerGetAllReceiveMessages")); // null, 예외처리 필요.
	if (pConsumerGetAllReceiveMessages == 0) {
		std::cout << "pConsumerGetAllReceiveMessages Ini : False" << std::endl;
		return 0;
	}
	/* pConsumerGetAllReceiveMessages
	* 입력 인자 (bool [실행 유무])
	*	[실행 유무]
	*		true 유지
	*
	* return 값
	*	수신 성공 - 브로커에서 수신된 데이터
	*	수신 실패
	*		- "False Value" : 입력값에 flase을 입력.
	*		- "Main.consumer is not Init" : 소비자 초기화 안됨.
	*		- "Null mess" : 리던값이 null
	*		- "오류 메시지" : Dll 오류.
	*/
	pClearAllMessages = (bool (*)(bool))(GetProcAddress(hActiveMQModerator, "ClearAllMessages"));
	if (pClearAllMessages == 0) {
		std::cout << "pClearAllMessages Ini : False" << std::endl;
		return 0;
	}

	pConsumerDispose = (bool (*)(bool))(GetProcAddress(hActiveMQModerator, "ConsumerDispose")); // null, 예외처리 필요.
	if (pConsumerDispose == 0) {
		std::cout << "pConsumerDispose Ini : False" << std::endl;
		return 0;
	}
	/* pProducerDispose
	* 입력 인자 (bool [실행 유무])
	*	[실행 유무]
	*		true 유지
	*
	* return 값
	*	true : 종료 완료
	*	false : 종료 실패
	*/
#pragma endregion

	char* brokerUri = (char*)"tcp://localhost:61616"; // 브로커 접속 URL
	char* queueName = (char*)"queue://queueTest"; // Q 접속시 사용
	char* topicName = (char*)"topic://topicTest"; // Topic 접속시 사용

	bool bBrokerUrlIsLive = (*pBrokerUrlIsLive)(brokerUri); // 접속 가능 여부 확인

	if (!bBrokerUrlIsLive) {
		std::cout << "BrokerUrlIsLive : " << bBrokerUrlIsLive << std::endl;
		return 0;
	}

	bool bProducerInitialize = (*pProducerInitialize)(brokerUri, queueName); // 생산자 초기화,

	for (int i = 0; i++ < 5;) {
		char buffer[4]; // 문자열 "Se"와 정수를 저장하기 위한 공간을 확보합니다.
		sprintf_s(buffer, sizeof(buffer), "Se%d", i); // sprintf_s 함수를 사용하여 문자열 "Se"와 정수를 합칩니다.
		(*pProducerSendMessage)(buffer);
	}
	bool bProducerSendMessage = (*pProducerSendMessage)((char*)"End Mes");

	bool bConsumerInitialize1 = (*pConsumerInitialize)(brokerUri, queueName);
	char* cConsumerReceiveMessage1 = (*pConsumerReceiveMessage)(true);
	char* cConsumerGetAllReceiveMessages1 = (*pConsumerGetAllReceiveMessages)(true);

	bool bClearAllMessages2 = (*pClearAllMessages)(true);

	bool bProducerDispose = (*pProducerDispose)(true);
	bool bConsumerDispose = (*pConsumerDispose)(true);

	std::cout << "bProducerInitialize : " << bProducerInitialize << std::endl;
	std::cout << "bProducerSendMessage : " << bProducerSendMessage << std::endl;
	std::cout << "bProducerDispose : " << bProducerDispose << std::endl;
	std::cout << "bConsumerInitialize 1 : " << bConsumerInitialize1 << std::endl;
	std::cout << "cConsumerReceiveMessage 1 : " << cConsumerReceiveMessage1 << std::endl;
	std::cout << "cConsumerGetAllReceiveMessages 1 : " << cConsumerGetAllReceiveMessages1 << std::endl;
	std::cout << "bConsumerDispose : " << bConsumerDispose << std::endl;
}

// 프로그램 실행: <Ctrl+F5> 또는 [디버그] > [디버깅하지 않고 시작] 메뉴
// 프로그램 디버그: <F5> 키 또는 [디버그] > [디버깅 시작] 메뉴

// 시작을 위한 팁:
//   1. [솔루션 탐색기] 창을 사용하여 파일을 추가/관리합니다.
//   2. [팀 탐색기] 창을 사용하여 소스 제어에 연결합니다.
//   3. [출력] 창을 사용하여 빌드 출력 및 기타 메시지를 확인합니다.
//   4. [오류 목록] 창을 사용하여 오류를 봅니다.
//   5. [프로젝트] > [새 항목 추가]로 이동하여 새 코드 파일을 만들거나, [프로젝트] > [기존 항목 추가]로 이동하여 기존 코드 파일을 프로젝트에 추가합니다.
//   6. 나중에 이 프로젝트를 다시 열려면 [파일] > [열기] > [프로젝트]로 이동하고 .sln 파일을 선택합니다.