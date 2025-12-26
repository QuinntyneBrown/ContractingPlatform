import type { StorybookConfig } from '@storybook/angular';

const config: StorybookConfig = {
  stories: ['../projects/contracting-platform-components/src/**/*.stories.@(js|jsx|mjs|ts|tsx)'],
  addons: [
    '@storybook/addon-essentials',
    '@storybook/addon-interactions',
    '@storybook/addon-links',
  ],
  framework: {
    name: '@storybook/angular',
    options: {},
  },
  docs: {},
  staticDirs: [],
};

export default config;
