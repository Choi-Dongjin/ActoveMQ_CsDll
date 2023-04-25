#pragma once
#include <iostream>
#include <Windows.h>
#include <string>
#include <string.h>    //strcmp
#include <unordered_map>
#include "json/json.h"

// AMQModerator class declaration
namespace ActiveMQC {
	enum class AMQMessageType {
		None,
		EAYT,
		AIRQ,
		AIRS,
		RRAM,
	};

	const std::unordered_map<std::string, AMQMessageType> stringToMessageType{
		{"None", AMQMessageType::None},
		{"EAYT", AMQMessageType::EAYT},
		{"AIRQ", AMQMessageType::AIRQ},
		{"AIRS", AMQMessageType::AIRS},
		{"RRAM", AMQMessageType::RRAM},
	};

	class AMQModerator {
	public:
		AMQModerator(const char* brokerUri, const char* destinationName);

		// Destructor (if necessary)
		~AMQModerator();

		// Other public methods for the class, e.g., Connect, SendMessage, etc.
		bool BrokerUriIsLive(char* url);
		bool Initialize();
		bool IsConnected();
		bool MQSendMessage(char* message);
		char* ReceiveMessage();
		bool MQMorderatorDispose();
		bool TESTInitSendMess_AIRQ();

	private:
		// Private member variables for the class, e.g., brokerUri, queueName, topicName, etc.
		HMODULE _hActiveMQModerator;
		const char* _brokerURL;
		const char* _destinationName;

		// Function pointers
		bool(*_pMQBrokerURLIsLive)(char*);
		bool(*_pMQInitialize)(char*, char*);
		bool(*_pMQIsConnected)(bool);
		bool(*_pMQSendMessage)(char*);
		char* (*_pMQReceiveMessage)(bool);
		bool(*_pMQMorderatorDispose)(bool);
		bool(*_pTESTInitSendMess_AIRQ)(bool);
		// Private methods (if any) used only internally by the class
	};

	class ActiveMQModeratorManager {
	public:
		ActiveMQModeratorManager(const char* brokerUris, const char* _destinationName);

		~ActiveMQModeratorManager();

		bool Initialize();
		bool MQSendMessage(char* message);
		char* ReceiveMessage();

	private:
		AMQModerator _amqModerator;
		const char* _brokerURL;
		const char* _destinationName;
	};
}
