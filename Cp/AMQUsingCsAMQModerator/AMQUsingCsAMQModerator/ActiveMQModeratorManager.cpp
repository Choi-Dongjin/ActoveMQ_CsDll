#include "AMQModerator.h"

using namespace ActiveMQC;

ActiveMQModeratorManager::ActiveMQModeratorManager(const char* brokerUri, const char* destinationName)
	: _brokerURL(brokerUri), _destinationName(destinationName), _amqModerator(brokerUri, destinationName) {
}

ActiveMQModeratorManager::~ActiveMQModeratorManager() {
	_amqModerator.MQMorderatorDispose();
}

bool ActiveMQModeratorManager::Initialize() {
	// ��Ƽ ���� ��� �߰� ���
	if (!_amqModerator.Initialize()) {
		return false;
	}
	return true;
}

bool ActiveMQModeratorManager::MQSendMessage(char* message) {
	if (!_amqModerator.MQSendMessage(message)) {
		return true;
	}
	return true;
}

char* ActiveMQModeratorManager::ReceiveMessage() {

	char* receiveMessage = _amqModerator.ReceiveMessage();
	if (strcmp(receiveMessage, "False Value") == 0) {
		// �Է� ���� �ҷ�, �Է� ���ڸ� True�� ����
	}
	else if (strcmp(receiveMessage, "Main.consumer is not Init") == 0) {
		// �ʱ�ȭ ���� ���̺귯�� Ȯ��
	}
	else if (strcmp(receiveMessage, "Null mess") == 0) {
		// ���� mess �ҷ�, �����ڿ� ����
	}

	Json::Value receiveData;
	Json::Reader reader;
	bool parsingSuccessful = reader.parse(receiveMessage, receiveData);
	if (!parsingSuccessful)	{
		std::cout << "Error Parsing to string Json failed." << std::endl;
	}

	if (receiveData["MessageName"].isNull()) {
		std::cout << "MessageName is Null" << std::endl;
		return NULL;
	}

	if (!receiveData["MessageName"].isString()) {
		std::cout << "MessageName Type is Strange" << std::endl;
		return NULL;
	}

	Json::FastWriter fastWriter;
	std::string messageName = fastWriter.write(receiveData["MessageName"]);
	char* c = (char*)messageName.data();
	if (messageName.empty()) {
		std::cout << "MessageName Data is empty" << std::endl;
		return NULL;
	}
	
	auto autoMessageType = ActiveMQC::stringToMessageType.find(messageName);
	if (autoMessageType == ActiveMQC::stringToMessageType.end()) {
		std::cout << "Invalid message type\n";
		return NULL;
	}

	ActiveMQC::AMQMessageType messageType = autoMessageType->second;

	switch (messageType)
	{
	case AMQMessageType::None:
		return NULL;
	case AMQMessageType::EAYT:
		return NULL;
	case AMQMessageType::AIRQ:
		return receiveMessage;
	case AMQMessageType::AIRS:
		return NULL;
	case AMQMessageType::RRAM:
		return NULL;
	default:
		return NULL;
	}
}