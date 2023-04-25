#include "AMQDatas.h"

ActiveMQCData::SynapseRuleResult::SynapseRuleResult() {
}

ActiveMQCData::SynapseRuleResult::SynapseRuleResult(std::string rowImagePath, std::string modelName, std::string modelVersion) : RAW_IMAGE_PATH(rowImagePath), MODEL_NAME(modelName), MODEL_VERSION(modelVersion) {
}

ActiveMQCData::SynapseRuleResult::~SynapseRuleResult() {
}

bool ActiveMQCData::SynapseRuleResult::AddSynapseDefectItem(std::string defectCode, std::string defectName, std::string cropPath, std::string reviewPath, std::string x, std::string y, std::string width, std::string height) {
	ActiveMQCData::SYNAPSE_DEFECT_ITEM SynapseDefctItem = { defectCode, defectName, cropPath, reviewPath, x, y, width, height };
	SYNAPSE_DEFECT_ITEM_LIST.push_back(SynapseDefctItem);
	return true;
}

std::string ActiveMQCData::SynapseRuleResult::Tostring() {
	Json::StyledWriter writer;
	std::string value = writer.write(ToJson());
	return value;
}

Json::Value ActiveMQCData::SynapseRuleResult::ToJson()
{
	Json::Value value;
	value[NAME_OF(RAW_IMAGE_PATH)] = RAW_IMAGE_PATH;
	value[NAME_OF(MODEL_NAME)] = MODEL_NAME;
	value[NAME_OF(MODEL_VERSION)] = MODEL_VERSION;

	Json::Value synapseDefectItemList;
	for (SYNAPSE_DEFECT_ITEM synapseDefectItem : SYNAPSE_DEFECT_ITEM_LIST) {
		synapseDefectItemList.append(synapseDefectItem.ToJson());
	}
	value[NAME_OF(SYNAPSE_DEFECT_ITEM_LIST)] = synapseDefectItemList;

	return value;
}