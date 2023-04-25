#include "AMQDatas.h"

ActiveMQCData::SYNAPSE_DEFECT_ITEM::SYNAPSE_DEFECT_ITEM() {
}

ActiveMQCData::SYNAPSE_DEFECT_ITEM::SYNAPSE_DEFECT_ITEM(std::string defectCode, std::string defectName, std::string cropPath, std::string reviewPath, std::string x, std::string y, std::string width, std::string height) : DEFECT_CODE(defectCode), DEFECT_NAME(defectName), CROP_PATH(cropPath), REVIEW_PATH(cropPath), x(x), y(x), width(width), height(height) {
}

ActiveMQCData::SYNAPSE_DEFECT_ITEM::~SYNAPSE_DEFECT_ITEM()
{
}

std::string ActiveMQCData::SYNAPSE_DEFECT_ITEM::Tostring() {
	Json::StyledWriter writer;
	std::string value = writer.write(ToJson());
	return value;
}

Json::Value ActiveMQCData::SYNAPSE_DEFECT_ITEM::ToJson()
{
	Json::Value value;
	value[NAME_OF(DEFECT_CODE)] = DEFECT_CODE;
	value[NAME_OF(DEFECT_NAME)] = DEFECT_NAME;
	value[NAME_OF(CROP_PATH)] = CROP_PATH;
	value[NAME_OF(REVIEW_PATH)] = REVIEW_PATH;
	value[NAME_OF(x)] = x;
	value[NAME_OF(y)] = y;
	value[NAME_OF(width)] = width;
	value[NAME_OF(height)] = height;
	return value;
}
